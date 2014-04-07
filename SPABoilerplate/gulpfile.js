var gulp = require('gulp');
var browserify = require('gulp-browserify');
var concat = require('gulp-concat');
var less = require('gulp-less');
var refresh = require('gulp-livereload');
var lr = require('tiny-lr');
var server = lr();
var minifyCSS = require('gulp-minify-css');
var embedlr = require('gulp-embedlr');

// gulp.task('scripts', function() {
//     gulp.src(['app/main/**/*.js'])
//         .pipe(browserify())
//         .pipe(concat('dest.js'))
//         .pipe(gulp.dest('dist/build'))
//         .pipe(refresh(server));
// });

gulp.task('lr-server', function() {
    server.listen(35729, function(err) {
        if (err) return console.log(err);
    });
});

gulp.task('scripts', function () {
    gulp.src("app/**/*.js")
        .pipe(refresh(server));
});


gulp.task('html', function() {
    gulp.src("./index.html")
        .pipe(refresh(server));
});

gulp.task('styles', function() {
    gulp.src(['app/assets/style/less/resources.less'])
        .pipe(less())
        .pipe(gulp.dest('app/assets/style/output'))
        .pipe(refresh(server));
});

gulp.task('watch', function() {
    gulp.watch(paths.styles, ['styles']);
    gulp.watch(paths.scripts, ['scripts']);
    gulp.watch(paths.html, ['html']);
});

var paths = {
    scripts: ['app/**/*.js'],
    styles: ['app/assets/**/*.less'],
    html: ['app/main/**/*.html']
};

gulp.task('default', ['lr-server', 'styles', 'watch']);