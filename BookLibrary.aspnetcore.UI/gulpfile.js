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

gulp.task('clean', function () {
    return del(jsDist, { force: true });
});

gulp.task('copy:libs:dev', function (done) {
    sequence('clean', 'copy:vendor:dev', 'copy:vendor:css', done);
});

gulp.task('copy:libs:prod', function (done) {
    sequence('clean', 'copy:vendor:prod', 'copy:vendor:css', done);
});

gulp.task('copy:vendor:css', function () {
    return gulp.src([
        libPath + '/bootstrap/dist/css/bootstrap.min.css',
        libPath + '/components-font-awesome/css/font-awesome.css',
        libPath + '/datatables.net-dt/css/jquery.dataTables.css',
        libPath + '/bootstrap3-dialog/dist/css/bootstrap-dialog.css',
        nodeModulesPath + '/toastr/build/toastr.min.css',
        nodeModulesPath + '/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css'
  ])
        .pipe(concat('scripts.vendor.css'))
        .pipe(gulp.dest(cssDist));
});

gulp.task('copy:vendor:dev', function () {
    return gulp.src([
        libPath + '/jquery/dist/jquery.js',
        libPath + '/bootstrap/dist/js/bootstrap.js',
        libPath + '/datatables.net/js/jquery.dataTables.js',
        libPath + '/bootstrap3-dialog/dist/js/bootstrap-dialog.js',
        nodeModulesPath + '/moment/moment.js',
        nodeModulesPath + '/toastr/toastr.js',
        nodeModulesPath + '/bootstrap-datepicker/dist/js/bootstrap-datepicker.js'
   ])
        .pipe(concat('scripts.vendor.js'))
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:vendor:prod', function () {
    return gulp.src([
        libPath + '/jquery/dist/jquery.js',
        libPath + '/bootstrap/dist/js/bootstrap.js',
        libPath + '/datatables.net/js/jquery.dataTables.js',
        libPath + '/bootstrap3-dialog/dist/js/bootstrap-dialog.js',
        nodeModulesPath + '/moment/moment.js',
        nodeModulesPath + '/toastr/toastr.js',
        nodeModulesPath + '/bootstrap-datepicker/dist/js/bootstrap-datepicker.js'
    ])
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

