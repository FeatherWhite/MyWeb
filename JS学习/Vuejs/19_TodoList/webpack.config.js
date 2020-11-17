// webpack.config.js
const path = require("path");
const VueLoaderPlugin = require("vue-loader/lib/plugin");
// const HotModuleReplacementPlugin = require('webpack');
// const HTMLWebpackPlugin = require('html-webpack-plugin');
module.exports = {
  entry: './src/main.js',
  output: {
    path: path.resolve(__dirname, "dist"),
    filename: "main.js",
  },
  mode: 'development',
  devServer: {
    contentBase: './dist'
  },
  resolve: {
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    },
    extensions: ['*', '.js', '.vue', '.json']
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
      },
      // 它会应用到普通的 `.js` 文件
      // 以及 `.vue` 文件中的 `<script>` 块
      {
        test: /\.m?js$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
          options: {
            presets: ['@babel/preset-env']
          }
        }
      },
      // 它会应用到普通的 `.css` 文件
      // 以及 `.vue` 文件中的 `<style>` 块
      {
        test: /\.css$/,
        use: ["style-loader", "css-loader"],
      },
      {
        test: /\.(png|svg|jpg|gif)$/,
        use: ["url-loader"]
      },
      {
        // 处理字体
        test: /\.(woff|woff2|eot|ttf|otf)$/,
        use: ["file-loader"],
      },
    ],
  },
  plugins: [
    // 请确保引入这个插件来施展魔法
    new VueLoaderPlugin(),
    //new HotModuleReplacementPlugin(),
  //   new HTMLWebpackPlugin({
  //     showErrors: true,
  //     cache: true,
  //     template: path.join(__dirname, './src/index.html')
  // })
  ],
};
