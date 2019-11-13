using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.AuthenticationClass
{
    //Bu sınıfın bir yetkilendirme işlemi yapması gerektigini bilmesi lazım. Bunu yapabilmesi icin .Net C#'ta bunu yapmasını saglayan bir sınıftan miras alması gerekir.

    //Sizin Attribute ile biten sınıflarınızın özelligi bunların bir Attribute Controller veya Action üzerine yazılarak onların üzerinde bir yetkilendirme gercekleştirebiliyor olmasıdır.
    public class EmployeeAuthentication : AuthorizeAttribute
    {
        //Yetkilendirmeyi kendimize göre özel yapmak istiyorsak AuthorizeCore isimli metodu override etmeliyiz.
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["oturum"] != null)
            {
                return true;
            }
            else
            {
                //eger session null ise giriş yapılmamıs demektir. Bu durumda kullanıcı aynı sayfaya yönlendirilecek ve yetiklendirme metodum false deger dönecektir.

                httpContext.Response.Redirect("/Home/Login"); //kullanıcıya Home Controller'ina Login Action'ına yönlendir.
                return false;
            }
        }
    }
}