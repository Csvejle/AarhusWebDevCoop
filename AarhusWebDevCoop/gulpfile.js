var gulp = require('gulp'); 
var sass = require('gulp-sass'); 
gulp.task('convert', function(){ 
    return gulp.src('Sass/**/*.scss')
        .pipe(sass().on('error', sass.logError)) // Converts Sass to CSS with gulp-sass 
        .pipe(gulp.dest('css/'))
});

// Gulp watch syntax 
gulp.task('SassToCss', function () {
    gulp.watch('Sass/**/*.scss', ['convert']);
    // Other watchers 
});

var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('styles', function () {
    gulp.src('../Sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('../CSS/'));
});

