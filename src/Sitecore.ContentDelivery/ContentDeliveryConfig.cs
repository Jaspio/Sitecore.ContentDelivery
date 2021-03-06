﻿// © 2015-2016 Sitecore Corporation A/S. All rights reserved.

using System.Web.Mvc;
using System.Web.Routing;

namespace Sitecore.ContentDelivery
{
    public static class ContentDeliveryConfig
    {
        public static void RegisterRoutes([NotNull] string basePath)
        {
            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetBundle", basePath + "/get", new
            {
                controller = "ContentDelivery",
                action = "GetBundle"
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetDatabases", basePath + "/get/databases", new
            {
                controller = "ContentDelivery",
                action = "GetDatabases"
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetDatabase", basePath + "/get/{databaseName}", new
            {
                controller = "ContentDelivery",
                action = "GetDatabase",
                databaseName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetChildren", basePath + "/get/children/{databaseName}/{*itemName}", new
            {
                controller = "ContentDelivery",
                action = "GetChildren",
                databaseName = "",
                itemName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetItems", basePath + "/get/items/{databaseName}", new
            {
                controller = "ContentDelivery",
                action = "GetItems",
                databaseName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetTemplate", basePath + "/get/template/{databaseName}/{*templateName}", new
            {
                controller = "ContentDelivery",
                action = "GetTemplate",
                databaseName = "",
                templateName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetTemplates", basePath + "/get/templates/{databaseName}", new
            {
                controller = "ContentDelivery",
                action = "GetTemplates",
                databaseName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.DumpDatabase", basePath + "/get/dump/{databaseName}", new
            {
                controller = "ContentDelivery",
                action = "DumpDatabase",
                databaseName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetItem", basePath + "/get/item/{databaseName}/{*itemName}", new
            {
                controller = "ContentDelivery",
                action = "GetItem",
                databaseName = "",
                itemName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.GetInsertOptions", basePath + "/get/insertoptions/{databaseName}/{*itemName}", new
            {
                controller = "ContentDelivery",
                action = "GetInsertOptions",
                databaseName = "",
                itemName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.PutItems", basePath + "/put/items/{databaseName}", new
            {
                controller = "ContentDelivery",
                action = "SaveItems",
                databaseName = ""
            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.DeleteItems", basePath + "/delete/items/{databaseName}/{*itemUri}", new
            {
                controller = "ContentDelivery",
                action = "DeleteItems",
                databaseName = "",
                itemUri = ""

            });

            RouteTable.Routes.MapRoute("Sitecore.ContentDelivery.AddItems", basePath + "/put/item/{databaseName}/{*itemPath}", new
            {
                controller = "ContentDelivery",
                action = "AddItem",
                databaseName = "",
                itemPath = ""
            });
        }
    }
}
