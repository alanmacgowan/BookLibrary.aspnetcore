/// <binding AfterBuild='copy:libs:dev' />
var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    del = require('del'),
    sequence = require('run-sequence'),
    jsPath = 'wwwroot/js',
    jsDist = 'wwwroot/js/dist',
    cssPath = 'wwwroot/css',
    cssDist = 'wwwroot/css/dist',
    libPath = 'wwwroot/lib',
    nodeModulesPath = 'node_modules';

var cssSourceFiles = [
    libPath + '/bootstrap/dist/css/bootstrap.min.css',
    libPath + '/components-font-awesome/css/font-awesome.css',
    libPath + '/datatables.net-dt/css/jquery.dataTables.css',
    libPath + '/bootstrap3-dialog/dist/css/bootstrap-dialog.css',
    nodeModulesPath + '/toastr/build/toastr.min.css',
    nodeModulesPath + '/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css',
    nodeModulesPath + '/select2/dist/css/select2.min.css'
];
var jsVendorSourceFiles = [
    libPath + '/jquery/dist/jquery.js',
    libPath + '/bootstrap/dist/js/bootstrap.js',
    libPath + '/datatables.net/js/jquery.dataTables.js',
    libPath + '/bootstrap3-dialog/dist/js/bootstrap-dialog.js',
    nodeModulesPath + '/moment/moment.js',
    nodeModulesPath + '/toastr/toastr.js',
    nodeModulesPath + '/bootstrap-datepicker/dist/js/bootstrap-datepicker.js',
    nodeModulesPath + '/select2/dist/js/select2.js',
    nodeModulesPath + '/axios/dist/axios.js'
];
var jsAppSourceFiles = [
    jsPath + '/backtotop.js',
    jsPath + '/spin.js',
    jsPath + '/utils.js'
];

gulp.task('clean', function () {
    return del(jsDist, { force: true });
});

gulp.task('copy:libs:dev', function (done) {
    sequence('clean', 'copy:app:dev', 'copy:vendor:dev', 'copy:vendor:css', done);
});

gulp.task('copy:libs:prod', function (done) {
    sequence('clean', 'copy:app:prod', 'copy:vendor:prod', 'copy:vendor:css', done);
});

gulp.task('copy:vendor:css', function () {
    return gulp.src(cssSourceFiles)
        .pipe(concat('styles.vendor.css'))
        .pipe(gulp.dest(cssDist));
});

gulp.task('copy:app:dev', function () {
    return gulp.src(jsAppSourceFiles)
        .pipe(concat('scripts.app.js'))
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:vendor:dev', function () {
    return gulp.src(jsVendorSourceFiles)
        .pipe(concat('scripts.vendor.js'))
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:app:prod', function () {
    return gulp.src(jsAppSourceFiles)
        .pipe(concat('scripts.app.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:vendor:prod', function () {
    return gulp.src(jsVendorSourceFiles)
        .pipe(concat('scripts.vendor.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});

gulp.task('watch', function () {

    gulp.watch([
        jsPath + '/**/*.js', ['compressScripts']
    ]);

});

gulp.task('default', ['compressScripts', 'watch']);

