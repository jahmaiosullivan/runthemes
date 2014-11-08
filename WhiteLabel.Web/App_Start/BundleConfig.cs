using System.Web.Optimization;

namespace RunThemes.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region "Main Site"
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/main.js",
                        "~/Scripts/Location.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/modernizr-*"
            ));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/styles.css",
                "~/Content/plugins/magnific-popup/magnific-popup.css"
            ));
            #endregion

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
           
            #region "JQuery"
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/plugins/jquery-ui/css/ui-lightness/jquery-ui-1.10.4.custom.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-*",
                        "~/Content/plugins/jquery-ui/js/jquery-ui-1.10.4.custom.js"
            ));
            #endregion

            #region "Twitter bootstrap"
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Content/plugins/bootstrap/bootstrap.min.js",
                "~/Content/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js"
            ));
            
            #endregion

            #region "Metronic theme css"
            bundles.Add(new StyleBundle("~/themes/metronic").Include(
                "~/Content/themes/metronic/css/style-metronic.css",
                "~/Content/themes/metronic/css/style.css",
                "~/Content/themes/metronic/css/style-responsive.css",
                "~/Content/themes/metronic/css/plugins.css",
                "~/Content/themes/metronic/css/default.css",
                "~/Content/themes/metronic/css/custom.css",
                "~/Content/themes/metronic/metronic_blue.css"
            ));

            bundles.Add(new StyleBundle("~/themes/metronic/ie9").Include(
                "~/Content/themes/metronic/plugins/respond.min.js",
                "~/Content/themes/metronic/plugins/excanvas.min.js"
            ));
            #endregion
            
            #region "Crevision theme css"
            bundles.Add(new StyleBundle("~/themes/crevision").Include(
                "~/Content/themes/crevision/css/style.css",
                "~/Content/themes/crevision/css/skins/blue.css",
                "~/Content/themes/crevision/css/layout/wide.css",
                "~/Content/themes/crevision/css/layout/switcher.css",
                "~/Content/themes/crevision/css/icons.css"
            ));

            bundles.Add(new StyleBundle("~/themes/crevision/ie9").Include(
                "~/Scripts/crevision/html5.js"
             ));
            #endregion

            #region "Non-JQuery plugins"
            bundles.Add(new StyleBundle("~/Content/plugins/other").Include(
                "~/Content/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/plugins/uniform/css/uniform.default.css",
                "~/Content/plugins/data-tables/DT_bootstrap.css",
                "~/Content/plugins/bootstrap/bootstrap-datepicker/css/datepicker.css",
                "~/Content/plugins/bootstrap/bootstrap-timepicker/compiled/timepicker.css",
                "~/Content/plugins/bootstrap/bootstrap-colorpicker/css/colorpicker.css",
                "~/Content/plugins/bootstrap/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Content/plugins/bootstrap/bootstrap-datetimepicker/css/datetimepicker.css",
                "~/Content/plugins/select2/select2_metro.css"
            ));
            
            bundles.Add(new ScriptBundle("~/bundles/plugins/other").Include(
                "~/Scripts/modernizr-*",
                "~/Scripts/handlebars-v1.3.0.js",
                "~/Scripts/knockout*",
                "~/Content/plugins/tytabs.js",
                "~/Content/plugins/bootstrap/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Content/plugins/bootstrap/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Content/plugins/bootstrap/bootstrap-daterangepicker/moment.min.js",
                "~/Content/plugins/bootstrap/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/plugins/ckeditor/ckeditor.js",
                "~/Scripts/MetroJs.lt.js",
                "~/Content/plugins/fancybox/jquery.fancybox.js",
                "~/Content/plugins/jquery.flexslider.js",
                "~/Scripts/jquery.jplayer.min.js",
                "~/Scripts/organictabs.jquery.js"
            ));
            #endregion
            
            #region "JQuery Plugins"
            bundles.Add(new ScriptBundle("~/bundles/plugins/fileupload").Include(
               "~/Content/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/load-image.min.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.iframe-transport.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/tmpl.min.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-process.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-image.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-audio.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-video.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-validate.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-ui.js",
                "~/Content/plugins/jquery-tags-input/jquery.tagsinput.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery/plugins").Include(
                "~/Content/plugins/jquery.cookie.js",
                "~/Content/plugins/jquery.uniform.min.js",
                "~/Content/plugins/jquery.flexslider.js",
                "~/Content/plugins/jquery.iconmenu.js",
                "~/Content/plugins/jquery.prettyPhoto.js",
                "~/Content/plugins/jquery.isotope.min.js",
                "~/Content/plugins/selectnav.js",
                "~/Content/plugins/jquery.ui.totop.js",
                "~/Content/plugins/jquery.tweet.js",
                "~/Content/plugins/jflickrfeed.min.js",
                "~/Content/plugins/jquery.cokie.min.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/load-image.min.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.iframe-transport.js",
                "~/Content/plugins/jquery-file-upload/js/vendor/tmpl.min.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-process.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-image.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-audio.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-video.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-validate.js",
                "~/Content/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js",
                "~/Content/plugins/jquery-file-upload/js/jquery.fileupload-ui.js",
                "~/Content/plugins/jquery-tags-input/jquery.tagsinput.min.js",
                "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Scripts/tag-it.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js" 
            ));

            bundles.Add(new StyleBundle("~/bundles/css/jquery/plugins").Include(
                "~/Content/plugins/jquery-file-upload/css/jquery.fileupload-ui.css",
                "~/Content/plugins/tagit/jquery.tagit.css",
                "~/Content/plugins/tagit/tagit.ui-zendesk.css"
            ));

            
            #endregion

            #region "Custom Validators"
            
            #endregion

        }
    }
}