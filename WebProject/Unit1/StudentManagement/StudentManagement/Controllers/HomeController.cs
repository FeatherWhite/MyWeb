using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IStudentRepository studentRepository,IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = null;
            students = _studentRepository.GetAllStudents();
            //ViewData["Student"] = model;
            return View(students);
        }
        //public JsonResult Action()
        //{
        //    var student = _studentRepository.GetStudent(1);
        //    return Json(student);
        //}
        public IActionResult Details(int id)
        {
            // throw new Exception("在Details视图中抛出异常");
            Student student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                ViewBag.ErrorMessage = $"学生Id={id}的信息不存在，请重试。";
                return View("NotFound");
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = student,
                PageTitle = "学生详情"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel studentModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + studentModel.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                //studentModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    studentModel.Photo.CopyTo(fs);
                }
                Student student = new Student
                {
                    Name = studentModel.Name,
                    Email = studentModel.Email,
                    ClassName = studentModel.ClassName,
                    // 将文件名保存在student对象的PhotoPath属性中。
                    //它将保存到数据库 Students的 表中
                    Photo = uniqueFileName
                };
                Student newStudent = _studentRepository.AddStudent(student);
                return RedirectToAction("Details", new { id = newStudent.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                ViewBag.ErrorMessage = $"学生Id={id}的信息不存在，请重试。";
                return View("NotFound");
                //Response.StatusCode = 404;
                //return View("StudentNotFound", id);
            }
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                ClassName = student.ClassName,
                ExistingPhotoPath = student.Photo
            };
            return View(studentEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel studentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(studentModel.Id);
                student.Name = studentModel.Name;
                student.Email = studentModel.Email;
                student.ClassName = studentModel.ClassName;
                if (studentModel.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, 
                        "images", studentModel.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                //当第一更新时不上传照片photo属性为空
                if(student.Photo != null)
                {
                    student.Photo = ProcessUploadedFile(studentModel);
                }
                Student updatedStudent = _studentRepository.UpdateStudent(student);
                return RedirectToAction("index");
            }
            return View(studentModel);
        }
        /// <summary>
        /// 将图片保存到指定的路径中,并返回唯一的文件名
        /// </summary>
        /// <returns> </returns>
        private string ProcessUploadedFile(StudentCreateViewModel model)
        {
            string uniqueFileName = null;
            var photo = model.Photo;
            //必须将图片文件上传到wwwroot的images/avatars文件夹中
            //而要获取wwwroot文件夹的路径,我们需要注入ASP.NET Core提供的
            //webHostEnvironment服务
            //通过webHostEnvironment服务去获取wwwroot文件夹的路径
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //为了确保文件名是唯一的,我们在文件名后附加一个新的GUID值和一
            //个下划线
            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //因为使用了非托管资源,所以需要手动进行释放
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                //使用IFormFile接口提供的CopyTo()方法将文件复制到
                //wwwroot/images/avatars文件夹
                photo.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
