﻿using System.Collections.Generic;
using System.Linq;
using Gallery3SelfHost;
using Selfhost.DTO;

namespace Gallery3SelfHost
{
    public abstract partial class Work
    {
        public clsWork MapToDTO()
        {
            clsWork lcWorkDTO = GetDTO();
            lcWorkDTO.Name = Name;
            lcWorkDTO.Date = Date;
            lcWorkDTO.Value = Value;
            lcWorkDTO.ArtistName = ArtistName;
            return lcWorkDTO;
        }

        protected abstract clsWork GetDTO();
    }

    public partial class Painting
    {
        protected override clsWork GetDTO()
        {
            return new clsPainting()
            { Width = this.Width, Height = this.Height, Type = this.Type };
        }
    }

    public partial class Photograph
    {
        protected override clsWork GetDTO()
        {
            return new clsPhotograph()
            { Width = this.Width, Height = this.Height, Type = this.Type };
        }
    }

    public partial class Sculpture
    {
        protected override clsWork GetDTO()
        {
            return new clsSculpture()
            { Weight = this.Weight, Material = this.Material };
        }
    }
}


