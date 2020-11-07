var path = require('path');

var config = {
    //入口:webpack从哪里开始寻找依赖，并编译
    entry: {
        main: './main'
    },
    //出口:用来配置编译后的文件存储位置和文件名
    output: {
        path: path.join(__dirname, "./dist"),
        publicPath: '/dist/',
        filename: 'main.js'
    }
};
//相当于export default config
module.exports = config;