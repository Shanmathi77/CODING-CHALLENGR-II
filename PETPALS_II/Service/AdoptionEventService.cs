using PETPALS_II.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETPALS_II.Service
{
   

namespace PETPALS_II.Service
    {
        internal class AdoptionEventService : IAdoptionEventService
        {
            private readonly IAdoptionEventRepository _adoptionEventRepository;

            public AdoptionEventService(IAdoptionEventRepository adoptionEventRepository)
            {
                _adoptionEventRepository = adoptionEventRepository;
            }

            public List<AdoptionEvent> GetAllAdoptionEvents()
            {
                return _adoptionEventRepository.GetAll();
            }

            public AdoptionEvent GetAdoptionEventById(int eventId)
            {
                return _adoptionEventRepository.GetById(eventId);
            }

            public void CreateAdoptionEvent(AdoptionEvent adoptionEvent)
            {
                if (adoptionEvent == null || string.IsNullOrWhiteSpace(adoptionEvent.Location))
                {
                    throw new ArgumentException("Invalid adoption event details.");
                }

                _adoptionEventRepository.Add(adoptionEvent);
            }

            public void UpdateAdoptionEvent(AdoptionEvent adoptionEvent)
            {
                if (adoptionEvent == null || adoptionEvent.EventId <= 0)
                {
                    throw new ArgumentException("Invalid adoption event details.");
                }

                _adoptionEventRepository.Update(adoptionEvent);
            }

            public void DeleteAdoptionEvent(int eventId)
            {
                if (eventId <= 0)
                {
                    throw new ArgumentException("Invalid event ID.");
                }

                _adoptionEventRepository.Delete(eventId);
            }

            public List<AdoptionEvent> GetAdoptionEventsByCriteria(string status, DateTime? startDate, DateTime? endDate)
            {
                var allEvents = _adoptionEventRepository.GetAll();

                if (!string.IsNullOrWhiteSpace(status))
                {
                    allEvents = allEvents.FindAll(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                }

                if (startDate.HasValue)
                {
                    allEvents = allEvents.FindAll(e => e.EventDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    allEvents = allEvents.FindAll(e => e.EventDate <= endDate.Value);
                }

                return allEvents;
            }
        }
    }

}
}
