using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.UI;

namespace CRUDWITHJSONINWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProduct" in both code and config file together.
    [ServiceContract]
    public interface IServiceProduct
    {
        [OperationContract]
        [WebInvoke (Method="GET",UriTemplate ="find/{id}",RequestFormat=WebMessageFormat.Json)]
        Product find(string id);
        [OperationContract]
        [WebInvoke(Method="GET",UriTemplate= "findall", RequestFormat =WebMessageFormat.Json)]
        List<Product> findall();
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", RequestFormat = WebMessageFormat.Json)]

        bool create(Product product);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", RequestFormat = WebMessageFormat.Json)]
        bool edit(Product product);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", RequestFormat = WebMessageFormat.Json)]
        bool delete(Product product);

    }
}
