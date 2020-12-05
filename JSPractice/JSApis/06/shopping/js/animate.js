function animate(obj, target,callback) {
    clearInterval(obj.timer);
    obj.timer = setInterval(function () {
        if (obj.offsetLeft == target) {
            clearInterval(obj.timer);
            callback && callback();
            //防止结束的时候再执行一次下面的计算
            return;
        }
        let step = (target - obj.offsetLeft) / 10;
        step = step >= 0 ? Math.ceil(step) : Math.floor(step);
        obj.style.left = obj.offsetLeft + step + "px";
    }, 15);
}