using System.Collections.Generic;
using System.Linq;
using Gallery3SelfHost;
using Selfhost.DTO;
using System;

namespace Gallery3Selfhost
{
    class Service1 : IService1
    //this interface is ABSTRACT. it is a promise of code.
    {
        public List<string> GetArtistNames() //this method only produces the name of artists
        {
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
                return lcContext.Artists
                    .Select(lcArtist => lcArtist.Name)
                    .ToList();
        }
        
        //this access the DTO.cs class file
        public clsArtist GetArtist(string prArtistName)
        //this is a service method to use clsArtist
        {
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
            {
                Artist lcArtist = lcContext.Artists
                    .Include("Works")
                    .Where(Artist => Artist.Name == prArtistName)
                    .FirstOrDefault();
                clsArtist lcArtistDTO = new clsArtist()
                { Name = lcArtist.Name, Speciality = lcArtist.Speciality, Phone = lcArtist.Phone, Works = new List<clsWork>() };
                foreach (Work item in lcArtist.Works)
                    lcArtistDTO.Works.Add(item.MapToDTO());
                return lcArtistDTO;
            }
        }

        //A generic method to CRUD any of the entities
        private int process<TEntity>(TEntity prItem, 
            System.Data.Entity.EntityState prState) where TEntity : class
            //this a type of class instead of a value like Int or Float
        {
            try
            {
                using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
                {
                    lcContext.Entry(prItem).State = prState;
                    int lcCount = lcContext.SaveChanges(); //flushes and changes everything
                                                           //this happens in RAM - it gurantees all changes are saved in the database
                    return lcCount; //returns the number of rows affected
                }
            }
            catch (System.Exception ex)
            {
                // alt" view inner error in client
                // throw ex.GetBaseException();
                Console.WriteLine(ex.GetBaseException().Message);
                return 0;
            }
        }

        public int UpdateArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Modified);
            //this passes the mapped entity and the desired state --> Modified
        }

        public int InsertArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Added);
        }

        public int DeleteArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Deleted);
        }

        public int UpdateWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Modified);
        }

        public int InsertWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Added);
        }
        public int DeleteWork(clsWork prWork)
        {
            return process(prWork.MapToEntity(), System.Data.Entity.EntityState.Deleted);
        }
    }
}