"use strict";
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const path = require("path")
module.exports = {
    mode: 'development',
    entry: {
        Site: './Styles/Site.scss',
        Icons: './Styles/Icons.scss'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot')
    },
    module: {
        rules: [
            // Extracts the compiled CSS from the SASS files defined in the entry
            {
                test: /\.scss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    {
                        // Interprets CSS
                        loader: "css-loader",
                        options: {
                            importLoaders: 2
                        }
                    },
                    {
                        loader: 'sass-loader'
                    }
                ]
            }
        ],
    },
    plugins: [
        // Where the compiled SASS is saved to
        new MiniCssExtractPlugin({
            filename: '[name].css',
        })
    ],
};