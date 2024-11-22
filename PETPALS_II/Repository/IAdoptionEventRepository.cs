using PETPALS_II.Model;
using System;
using System.Collections.Generic;

namespace PETPALS_II.Repository
{
    internal interface IAdoptionEventRepository
    {
     
        List<AdoptionEvent> GetAllAdoptionEvents();
        AdoptionEvent GetAdoptionEventById(int eventId);
        void AddAdoptionEvent(AdoptionEvent adoptionEvent);
        void UpdateAdoptionEvent(AdoptionEvent adoptionEvent);
        void DeleteAdoptionEvent(int eventId);
        List<AdoptionEvent> GetAll();
        AdoptionEvent GetById(int eventId);
        void Add(AdoptionEvent adoptionEvent);
        void Update(AdoptionEvent adoptionEvent);
        void Delete(int eventId);
    }
}
