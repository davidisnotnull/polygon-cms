const merge = require("webpack-merge");

const { BundleAnalyzerPlugin } = require("webpack-bundle-analyzer");
const baseConfig = require("./webpack.common");


let analyse = {};
let sharedChunkNames = {};

if (process.env.ANALYSE) {
  analyse = {
    plugins: [new BundleAnalyzerPlugin()],
  };
}

if (!process.env.ANALYSE) {
  sharedChunkNames = {
    optimization: {
      splitChunks: {
        name: false,
      },
    },
  };
}

module.exports = merge.smart(baseConfig, {
  mode: "production",
  devtool: "",
  ...analyse,
  ...sharedChunkNames,
});
