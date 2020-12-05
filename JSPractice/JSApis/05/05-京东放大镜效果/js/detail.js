window.addEventListener("load", function () {
    let preview_img = document.querySelector(".preview_img");
    let mask = document.querySelector(".mask");
    let big = document.querySelector(".big");
    let bigImg = document.querySelector(".bigImg");
    preview_img.addEventListener("mouseover", function (e) {
        mask.style.display = "block";
        big.style.display = "block";
    });
    preview_img.addEventListener("mouseout", function () {
        mask.style.display = "none";
        big.style.display = "none";
    });
    preview_img.addEventListener("mousemove", function (e) {
        let x = e.pageX - preview_img.offsetLeft - mask.offsetWidth / 2;
        let y = e.pageY - preview_img.offsetTop - mask.offsetHeight / 2;
        if(x < 0){
            x = 0;
        }
        if(y < 0){
            y = 0;
        }
        if(x > 150){
            x = 150;
        }
        if(y > 150){
            y = 150;
        }
        mask.style.left = x + "px";
        mask.style.top = y + "px";
        // if (x >= 0) {
        //     mask.style.left = x + "px";
        // } else {
        //     mask.style.left = 0;
        // }
        // if (y >= 0) {
        //     mask.style.top = y + "px";
        // } else {
        //     mask.style.top = 0;
        // }
        // if (x > 150) {
        //     mask.style.left = "150px";
        // }
        // if (y > 150) {
        //     mask.style.top = "150px";
        // }
        let smallX = preview_img.offsetWidth - mask.offsetWidth;
        let smallY = preview_img.offsetHeight - mask.offsetHeight;
        let bigX = big.offsetWidth - bigImg.offsetWidth;
        let bigY = big.offsetHeight - bigImg.offsetHeight;
        // if(x > 0){
        //     bigImg.style.left = x * (bigX / smallX) + "px";
        // }
        // else{
        //     bigImg.style.left = 0;
        // }
        bigImg.style.left = x * (bigX / smallX) + "px";
        console.log("x:" + x + "," + "bigImgX:" + bigImg.style.left);
        bigImg.style.top = y * (bigY / smallY) + "px";
        // bigImg.style.left =x * (- mask.offsetWidth / bigImg.offsetWidth) + "px";
        // bigImg.style.top =y * (-mask.offsetHeight / bigImg.offsetHeight) + "px";
    });
});