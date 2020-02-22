const { src, dest, watch, series, parallel } = require('gulp');
const sourcemaps = require('gulp-sourcemaps');
const sass = require('gulp-sass');
const concat = require('gulp-concat');
const uglify = require('gulp-uglify');
const postcss = require('gulp-postcss');
const autoprefixer = require('autoprefixer');
const cssnano = require('cssnano');
var replace = require('gulp-replace');

// File paths
const files = {
    scssPath: 'Content/scss/**/*.scss',
    jsPath: 'Content/js/**/*.js'
}

// Sass task: compiles the style.scss file into style.css
function scssTask() {
    return src(files.scssPath)
        .pipe(sourcemaps.init())
        .pipe(sass())
        .pipe(postcss([autoprefixer(), cssnano()]))
        .pipe(sourcemaps.write('.'))
        .pipe(dest('wwwroot/css')
        );
}

// JS task: concatenates and uglifies JS files to script.js
function jsTask() {
    return src([
        files.jsPath
        //,'!' + 'includes/js/jquery.min.js', // to exclude any specific files
    ])
        .pipe(concat('app.js'))
        .pipe(uglify())
        .pipe(dest('wwwroot/js')
        );
}

// Cachebust
function cacheBustTask() {
    var cbString = new Date().getTime();
    return src(['index.html'])
        .pipe(replace(/cb=\d+/g, 'cb=' + cbString))
        .pipe(dest('.'));
}

// Watch task: watch SCSS and JS files for changes
// If any change, run scss and js tasks simultaneously
function watchTask() {
    watch([files.scssPath, files.jsPath],
        { interval: 1000, usePolling: true },
        series(
            parallel(scssTask, jsTask)
            //cacheBustTask
        )
    );
}

// Export the default Gulp task so it can be run
// Runs the scss and js tasks simultaneously
// then runs cacheBust, then watch task
exports.default = series(
    parallel(scssTask, jsTask),
    //cacheBustTask,
    watchTask
);