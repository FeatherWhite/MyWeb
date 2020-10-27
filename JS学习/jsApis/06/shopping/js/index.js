window.addEventListener("load", function () {
    let arrowL = document.querySelector(".arrow-l");
    let arrowR = document.querySelector(".arrow-r");
    let focus = document.querySelector(".focus");
    let focusWidth = focus.offsetWidth;
    let ulImgs = focus.querySelector("ul");
    let circles = document.querySelector(".circle");
    let liCircle = circles.querySelector("li");
    let pic1stClone = ulImgs.firstElementChild.cloneNode(true);
    let picCount = ulImgs.children.length;
    let num = 0;

    ulImgs.appendChild(pic1stClone);

    focus.addEventListener("mouseenter", function () {
        arrowL.style.display = "block";
        arrowR.style.display = "block";
        clearInterval(timer);
        timer = null;
    });

    focus.addEventListener("mouseleave", function () {
        arrowL.style.display = "none";
        arrowR.style.display = "none";
        timer = setInterval(function () {
            //手动调用点击事件
            arrowR.click();
        }, 2000);
    });

    for (let i = 0; i < picCount; i++) {
        let li = document.createElement("li");
        circles.appendChild(li);
        circles.children[i].setAttribute("index", i);
        li.addEventListener("click", function () {
            num = this.getAttribute("index");
            moveImage(num);
        });
    }
    circles.firstElementChild.className = "current";
    // 点击左右箭头滚动图片 start
    let flag = true;
    arrowR.addEventListener("click", function () {
        //用来跳过排在开头的第一张图片
        //第一张图用来欺骗眼睛
        if(flag){
            flag = false;
            if (num == picCount) {
                num = 0;
            }
            num++;
            moveImage(num, "R");
        }
        // changeCircle(num);
    });
    arrowL.addEventListener("click", function () {
        //用来跳过倒数第一张图片
        if(flag){
            flag = false;
            if (num == 0) {
                num = picCount;
            }
            num--;
            moveImage(num, "L");
        }
        // changeCircle(num);
    });
    // 点击左右箭头滚动图片 end
    // 自动播放轮播图 start
    var timer = setInterval(function () {
        //手动调用点击事件
        arrowR.click();
    }, 2000);
    // 自动播放轮播图 end
    //#region 函数
    //移动图片函数
    //节流阀开关
    function moveImage(num, direction) {
        let index = num;
        let target = (- focusWidth * index);
        console.log("num" + ":" + num);
        console.log("index" + ":" + index);
        // animate(ulImgs, distance);
        if (direction == "R" && index == 1) {
            ulImgs.style.left = 0;
        }
        if (direction == "L" && index == picCount - 1) {
            ulImgs.style.left = -picCount * focusWidth + "px";
        }
        animate(ulImgs, target, function () {
            flag = true;
        });
        changeCircle(num);
    }

    //切换小圆点函数
    function changeCircle(num) {
        let index = num % picCount;
        console.log("circle num:" + num);
        for (let i = 0; i < picCount; i++) {
            circles.children[i].className = "";
        }
        circles.children[index].className = "current";
    }
    //#endregion 函数

});