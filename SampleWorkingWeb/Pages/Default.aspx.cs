using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWorkingWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Uri redirectUrl;
            switch (SharePointContextProvider.CheckRedirectionStatus(Context, out redirectUrl))
            {
                case RedirectionStatus.Ok:
                    return;
                case RedirectionStatus.ShouldRedirect:
                    Response.Redirect(redirectUrl.AbsoluteUri, endResponse: true);
                    break;
                case RedirectionStatus.CanNotRedirect:
                    Response.Write("An error occurred while processing your request.");
                    Response.End();
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // The following code gets the client context and Title property by using TokenHelper.
            // To access other properties, the app may need to request permissions on the host web.
            var spContext = SharePointContextProvider.Current.GetSharePointContext(Context);
            User spUser = null;
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                //clientContext.Load(clientContext.Web, web => web.Title);
                //clientContext.ExecuteQuery();
                //Response.Write(clientContext.Web.Title);

                if (clientContext != null)
                {
                    Web web = clientContext.Web;
                    var props = web.AllProperties;
                    web.Context.Load(props);
                    web.Context.ExecuteQuery();

                    props["test"] = "update";
                    web.Update();
                    web.Context.ExecuteQuery();


                    clientContext.Load(web, w => w.AllProperties);
                    clientContext.ExecuteQuery();
                    Response.Write(web.AllProperties["test"].ToString());
                  //  Response.Write("updated successfully");
                    //clientContext.Load(web, web2 => web2.Title);
                    //clientContext.ExecuteQuery();
                    //Response.Write(web.Title);
                }
            }





        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {

            // The following code gets the client context and Title property by using TokenHelper.
            // To access other properties, the app may need to request permissions on the host web.
            var spContext = SharePointContextProvider.Current.GetSharePointContext(Context);
            User spUser = null;
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                //clientContext.Load(clientContext.Web, web => web.Title);
                //clientContext.ExecuteQuery();
                //Response.Write(clientContext.Web.Title);

                if (clientContext != null)
                {
                    Web web = clientContext.Web;
                    var props = web.AllProperties;
                    web.Context.Load(props);
                    web.Context.ExecuteQuery();

                    //props["test"] = "update";
                    //web.Update();
                    //web.Context.ExecuteQuery();


                    clientContext.Load(web, w => w.AllProperties);
                    clientContext.ExecuteQuery();
                    Response.Write(web.AllProperties["test"].ToString());
                    Response.Write("updated successfully");
                    //clientContext.Load(web, web2 => web2.Title);
                    //clientContext.ExecuteQuery();
                    //Response.Write(web.Title);
                }
            }

        }
    }
}