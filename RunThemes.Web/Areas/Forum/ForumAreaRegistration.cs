using System.Web.Mvc;

namespace RunThemes.Web.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Forum_Home",
                "Forum",
                new { action = "List", controller = "Forums" },
                new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "PageContents",
                "Forum/p/{name}",
                new { action = "Detail", controller = "PageContents" },
                constraints: new { name = @"^[\w\-%]+$" },
                namespaces:new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "TopicDetails",
                "Forum/{forum}/{name}-{id}/{page}",
                new { action = "Detail", controller = "Topics", page=0 },
                constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"^\d+$", page = @"^\d+$" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "PageMore",
                "Forum/{forum}/{name}-{id}/page-more",
                new { action = "PageMore", controller = "Topics" },
                constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"^\d+$" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "PageUntil",
                "Forum/{forum}/{name}-{id}/page-until",
                new { action = "PageUntil", controller = "Topics" },
                constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"^\d+$" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "Login",
                "Forum/login/",
                new { action = "Login", controller = "Authentication" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "changepasswordsuccess",
                "Forum/formsauth/changepasswordsuccess",
                new { controller = "FormsAuthentication", action = "ChangePasswordSuccess" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "changepassword",
                "Forum/formsauth/changepassword",
                new { controller = "FormsAuthentication", action = "ChangePassword" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "newpassword",
                "Forum/formsauth/newpassword/{guid}",
                new { controller = "FormsAuthentication", action = "NewPassword" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "Register",
                "Forum/formsauth/register",
                new { controller = "FormsAuthentication", action = "Register" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "baseLogin",
                "Forum/formsauth/login",
                new { controller = "FormsAuthentication", action = "Login" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );
            context.MapRoute(
                "resetpwd",
                "Forum/formsauth/resetpwd",
                new { controller = "FormsAuthentication", action = "ResetPassword" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "CustomLogin",
                "Forum/login/custom",
                new { controller = "Authentication", action = "CustomLogin" },
                namespaces: new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
               "logout",
               "Forum/logout",
               new { controller = "Authentication", action = "Logout" },
               namespaces: new[] { "NearForums.Web.Controllers" }
           );

            context.MapRoute(
               "Error",
               "Forum/Error",
               new { controller = "Home", action = "Error" },
               namespaces: new[] { "NearForums.Web.Controllers" }
           );

            
          context.MapRoute(
               "captcha",
               "Forum/captcha",
               new { controller = "Base", action = "Captcha" },
               namespaces: new[] { "NearForums.Web.Controllers" }
           );

          
          context.MapRoute(
                  "unsubscribe",
                  "Forum/users/{uid}/unsubscribe",
                  new { controller = "TopicsSubscriptions", action = "Unsubscribe" },
                  constraints: new { uid = @"\d+" },
                  namespaces: new[] { "NearForums.Web.Controllers" }
              );

          context.MapRoute(
             "AddTemplates",
             "Forum/admin/templates/add",
             new { controller = "Templates", action = "Add" },
             namespaces: new[] { "NearForums.Web.Controllers" }
         );

        context.MapRoute(
           "SetCurrentTemplates",
           "Forum/admin/templates/set",
           new { controller = "Templates", action = "SetCurrent" },
           namespaces: new[] { "NearForums.Web.Controllers" }
       );
        context.MapRoute(
           "DeleteTemplates",
           "Forum/admin/templates/delete",
           new { controller = "Templates", action = "Delete" },
           namespaces: new[] { "NearForums.Web.Controllers" }
       );

        context.MapRoute(
               "ExportTemplates",
               "Forum/admin/templates/export",
               new { controller = "Templates", action = "Export" },
               namespaces: new[] { "NearForums.Web.Controllers" }
           );

        context.MapRoute(
           "PreviewTemplates",
           "Forum/admin/templates/preview",
           new { controller = "Templates", action = "Preview" },
           namespaces: new[] { "NearForums.Web.Controllers" }
       );

        context.MapRoute(
            "AddDefaultTemplates",
            "Forum/admin/templates/add-defaults",
            new { controller = "Templates", action = "AddDefaultTemplates" },
            namespaces: new[] { "NearForums.Web.Controllers" }
        );

        context.MapRoute(
            "ListTemplates",
            "Forum/admin/templates/",
            new { controller = "Templates", action = "List" },
            namespaces: new[] { "NearForums.Web.Controllers" }
        );

        context.MapRoute(
            "ListFlagged",
            "Forum/admin/messages/flagged/{page}",
            new { controller = "Messages", action = "ListFlagged", page = 0 },
            constraints: new { page = @"\d+" },
            namespaces: new[] { "NearForums.Web.Controllers" }
        );

        

    context.MapRoute(
            "ManageForums",
            "Forum/admin/forums/",
            new { controller = "Forums", action = "Manage" },
            namespaces: new[] { "NearForums.Web.Controllers" }
        );
    context.MapRoute(
        "AddForums",
        "Forum/admin/forums/add",
        new { controller = "Forums", action = "Add" },
        namespaces: new[] { "NearForums.Web.Controllers" }
    );

    context.MapRoute(
        "EditForums",
        "Forum/admin/forums/edit",
        new { controller = "Forums", action = "Edit" },
        namespaces: new[] { "NearForums.Web.Controllers" }
        );

    context.MapRoute(
        "DeleteForums",
        "Forum/admin/forums/delete",
        new { controller = "Forums", action = "Delete" },
        namespaces: new[] { "NearForums.Web.Controllers" }
    );

    context.MapRoute(
            "ListAllUnansweredTopics",
            "Forum/admin/unanswered-threads/{page}",
            new { controller = "Forums", action = "ListAllUnansweredTopics", page =0 },
            constraints: new { page = @"\d+" },
            namespaces: new[] { "NearForums.Web.Controllers" }
    );


    context.MapRoute(
        "ManageSearchEngine",
        "Forum/admin/search-index/",
        new { controller = "SearchEngine", action = "Manage" },
        namespaces: new[] { "NearForums.Web.Controllers" }
    );

    context.MapRoute(
        "ReindexStart",
        "Forum/admin/search-index/reindex-start",
        new { controller = "SearchEngine", action = "ReindexStart" },
        namespaces: new[] { "NearForums.Web.Controllers" }
        );


    context.MapRoute(
"IndexBatch",
"Forum/admin/search-index/batch",
new { controller = "SearchEngine", action = "IndexBatch" },
namespaces: new[] { "NearForums.Web.Controllers" }
);


    context.MapRoute(
"ListPageContents",
"Forum/admin/pages/",
new { controller = "PageContents", action = "List" },
namespaces: new[] { "NearForums.Web.Controllers" }
);

    context.MapRoute(
"AddPageContents",
"Forum/admin/pages/add",
new { controller = "PageContents", action = "Add" },
namespaces: new[] { "NearForums.Web.Controllers" }
);

    context.MapRoute(
"ListForumCategories",
"Forum/admin/forumcategories/",
new { controller = "ForumCategories", action = "List" },
namespaces: new[] { "NearForums.Web.Controllers" }
);

    context.MapRoute(
        "AddForumCategories",
        "Forum/admin/forumcategories/add",
        new { controller = "ForumCategories", action = "Add" },
        namespaces: new[] { "NearForums.Web.Controllers" }
        );

    context.MapRoute(
"EditForumCategories",
"Forum/admin/forumcategories/edit",
new { controller = "ForumCategories", action = "Edit" },
namespaces: new[] { "NearForums.Web.Controllers" }
);
    context.MapRoute(
        "DeleteForumCategories",
        "Forum/admin/forumcategories/delete",
        new { controller = "ForumCategories", action = "Delete" },
        namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
"EditGeneralSettings",
"Forum/admin/settings/general",
new { controller = "Settings", action = "EditGeneral" },
namespaces: new[] { "NearForums.Web.Controllers" });


    context.MapRoute(
"EditUISettings",
"Forum/admin/settings/ui",
new { controller = "Settings", action = "EditUI" },
namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
"EditSpamPrevention",
"Forum/admin/settings/spam",
new { controller = "Settings", action = "EditSpamPrevention" },
namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
"SettingsSearchToggle",
"Forum/admin/settings/search-toggle",
new { controller = "Settings", action = "SearchToggle" },
namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
"PageContentsEdit",
"Forum/p/{name}/edit",
new { controller = "PageContents", action = "Edit" },
constraints: new { name = @"[\w\-%]+" },
                namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
   "PageContentsDelete",
   "Forum/p/{name}/delete",
   new { controller = "PageContents", action = "Delete" },
   constraints: new { name = @"[\w\-%]+" },
                   namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
     "AdminDashboard",
     "Forum/admin/",
     new { controller = "Admin", action = "Dashboard" },
     namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
 "ForumsLatestAllTopics",
 "Forum/rss",
 new { controller = "Forums", action = "LatestAllTopics" },
                 namespaces: new[] { "NearForums.Web.Controllers" });

    context.MapRoute(
"ForumsListUnansweredTopics",
"Forum/{forum}/unanswered",
new { controller = "Forums", action = "ListUnansweredTopics" },
constraints: new { forum = @"[\w\-%]+" },
                namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"ForumsLatestTopicsHtml",
"Forum/{forum}/latest/{page}",
new { controller = "Forums", action = "LatestTopics", page = 0, format="Html" },
constraints: new { forum = @"[\w\-%]+", page=@"\d+" },
        namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
"ForumsMostViewedTopics",
"Forum/{forum}/most-viewed/{page}",
new { controller = "Forums", action = "MostViewedTopics", page = 0 },
constraints: new { forum = @"[\w\-%]+", page = @"\d+" },
        namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
     "ForumsLatestTopicsRss",
     "Forum/{forum}/rss",
     new { controller = "Forums", action = "LatestTopics", page = 0, format = "Rss" },
     constraints: new { forum = @"[\w\-%]+", page = @"\d+" },
             namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"AddTopics",
"Forum/{forum}/create-thread",
new { controller = "Topics", action = "Add" },
constraints: new { forum = @"[\w\-%]+" },
     namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
   "ForumsTagDetail",
   "Forum/{forum}/tags/{tag}/{page}",
   new { controller = "Forums", action = "TagDetail", page = 0 },
   constraints: new { forum = @"[\w\-%]+", tag = @"[\w\-\.]+", page = @"\d+" },
        namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"MoveTopics",
"Forum/{forumName}/{name}-{id}/move",
new { controller = "Topics", action = "Move" },
constraints: new { forumName = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
 namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
"TopicsCloseReplies",
"Forum/{forum}/{name}-{id}/close",
new { controller = "Topics", action = "CloseReplies" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"DeleteTopics",
"Forum/{forum}/{name}-{id}/delete",
new { controller = "Topics", action = "Delete" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"TopicsOpenReplies",
"Forum/{forum}/{name}-{id}/open",
new { controller = "Topics", action = "OpenReplies" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
 "AddMessages",
 "Forum/{forum}/{name}-{id}/reply",
 new { controller = "Messages", action = "Add" },
 constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
 namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
 "TopicsLatestMessages",
 "Forum/{forum}/{name}-{id}/rss",
 new { controller = "Topics", action = "LatestMessages" },
 constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
 namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
"EditTopics",
"Forum/{forum}/{name}-{id}/edit",
new { controller = "Topics", action = "Edit" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"FlagTopics",
"Forum/{forum}/{name}-{id}/flag-topic",
new { controller = "Topics", action = "Flag" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
    "DeleteMessages",
    "Forum/{forum}/{name}-{id}/delete-message-{messageId}",
    new { controller = "Messages", action = "Delete" },
    constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+", messageId = @"\d+" },
    namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"FlagMessages",
"Forum/{forum}/{name}-{id}/flag-message",
new { controller = "Messages", action = "Flag" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+"},
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"ClearFlagsMessages",
"Forum/{forum}/{name}-{id}/clear-flags",
new { controller = "Messages", action = "ClearFlags" },
constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
     "EditMessages",
     "Forum/{forum}/{name}-{id}/edit-message-{messageId}",
     new { controller = "Messages", action = "Edit" },
     constraints: new { forum = @"[\w\-%]+", name = @"[\w\-%]+?", id = @"\d+", messageId = @"\d+" },
     namespaces: new[] { "NearForums.Web.Controllers" });

     context.MapRoute(
"TopicsShortUrl",
"Forum/{id}",
new { controller = "Topics", action = "ShortUrl" },
constraints: new { id = @"\d+" },
namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
"ForumsDetail",
"Forum/{forum}/{page}",
new { controller = "Forums", action = "Detail", page=0 },
constraints: new { forum = @"[\w\-%]+", page = @"^\d+$" },
namespaces: new[] { "NearForums.Web.Controllers" });


     context.MapRoute(
  "NotFound",
  "Forum/notfound",
  new { controller = "Home", action = "NotFound", page = 0 },
  namespaces: new[] { "NearForums.Web.Controllers" });



        
        }
    }
}