const path = require("path");
const config = require("./webpack.config");

const devMode = process.env.NODE_ENV !== "production";

module.exports = {
  mode: "development",
  output: {
    filename: "js/[name].[hash].js",
    path: path.resolve(__dirname, config.OUTPUT_DIR),
    publicPath: "/wwwroot/dist/",
  },
  node: {
    __filename: false,
    __dirname: false,
  },
  resolve: {
    extensions: [".ts", ".tsx", ".js", ".jsx", ".json"],
  },
  devtool: "source-map",
};