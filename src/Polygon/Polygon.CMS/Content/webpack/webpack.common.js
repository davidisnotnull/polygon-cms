require("@babel/polyfill");

const path = require("path");

const merge = require("webpack-merge");

const TerserJSPlugin = require("terser-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const CompressionPlugin = require("compression-webpack-plugin");
const config = require("./webpack.config");

const devMode = process.env.NODE_ENV !== "production";

const baseConfig = require("./webpack.base");

const obfuscation = [];
const brotli = [];

if (config.OBFUSCATION) {
  obfuscation.push(new TerserJSPlugin({}));
}

if (config.BROTLI) {
  brotli.push(
    new CompressionPlugin({
      filename: "[path].br[query]",
      algorithm: "brotliCompress",
      test: /\.(js|css)$/,
      compressionOptions: { level: 11 },
      threshold: 10240,
      minRatio: 0.8,
    }),
  );
}

module.exports = merge.smart(baseConfig, {
  entry: {
    [config.BUNDLE_NAME]: [
      "@babel/polyfill",
      "whatwg-fetch",
      path.resolve(__dirname, config.ENTRYPOINTS.TS),
    ],
  },
  plugins: [
    new CleanWebpackPlugin(),
    new MiniCssExtractPlugin({
      filename: "css/[name].css",
      chunkFilename: "css/[name]-[id].css",
      ignoreOrder: false,
    }),
    ...brotli,
  ],
  module: {
    rules: [
      {
        test: /\.(t|j)(s|sx)$/,
        exclude: /node_modules/,
        loader: "babel-loader",
        options: {
          cacheDirectory: true,
          plugins: [
            "@babel/plugin-proposal-class-properties",
            "@babel/plugin-syntax-dynamic-import",
            "@babel/plugin-proposal-optional-chaining",
            ["@babel/plugin-transform-react-jsx", {
              "pragma": "h",
              "pragmaFrag": "Fragment",
            }]
          ],
          presets: [
            //"@babel/preset-react",
            [
              "@babel/preset-env",
              {
                targets: {
                  ie: "11",
                },
                modules: false,
              },
            ],
            "@babel/preset-typescript",
          ],
        },
      },
      {
        test: /\.(sa|sc|c)ss$/,
        use: [
          {
            loader: MiniCssExtractPlugin.loader,
          },
          {
            loader: "css-loader",
          },
          {
            loader: "postcss-loader",
            options: {
              config: {
                path: "./webpack"
              }
            }
          },
          {
            loader: "sass-loader"
          }
        ],
        sideEffects: true
      },
      // All output ".ts/.js" files will have any sourcemaps re-processed by "source-map-loader".
      {
        enforce: "pre",
        test: /\.(t|j)(s|sx)$/,
        loader: "source-map-loader",
      },
    ],
  },
  
  optimization: {
    minimizer: [new OptimizeCSSAssetsPlugin({}), ...obfuscation],
  },
});