using Selfhost.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Gallery3Selfhost
{
    [ServiceContract]
    interface IService1 //implemented in App.config.cs
    {
        [OperationContract]
        List<string> GetArtistNames();

        [OperationContract]
        clsArtist GetArtist(string prArtistName);

        [OperationContract]
        int UpdateArtist(clsArtist prArtist);

        [OperationContract]
        int InsertArtist(clsArtist prArtist);

        [OperationContract]
        int DeleteArtist(clsArtist prArtist);

        [OperationContract]
        int UpdateWork(clsWork prWork);

        [OperationContract]
        int InsertWork(clsWork prWork);

        [OperationContract]
        int DeleteWork(clsWork prWork);
    }
}