const path = require("path");

const webpack = require("webpack");
const merge = require("webpack-merge");
const config = require("./webpack.config");

const baseConfig = require("./webpack.common");

const devMode = process.env.NODE_ENV !== "production";

module.exports = merge.smart(baseConfig, {
  devServer: {
    contentBase: config.OUTPUT_DIR,
  },
  output: {
    filename: "js/[name].js",
    path: path.resolve(__dirname, config.OUTPUT_DIR),
  },
});