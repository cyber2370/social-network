"use strict";

var WebpackNotifierPlugin = require('webpack-notifier');

module.exports = {
    entry: "./scripts/react/index.js",

    output: {
        filename: "./dist/bundle.js"
    },

    devServer: {
        contentBase: ".",
        host: "localhost",
        port: 9000
    },

    module: {
        loaders: [
            { 
                test: /\.js$/, 
                exclude: /node_modules/, 
                loader: ['babel-loader'],
                query: {
                    presets: ['es2015', 'react']
                }
            }
        ]
    },

    watch: true,
    
    plugins: [
        new WebpackNotifierPlugin()
    ]
};