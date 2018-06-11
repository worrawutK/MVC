using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ReservationClient client = new ReservationClient();
            return View(client.ReadAll());
        }

        public ViewResult Create()
        {
            return View("Edit", new Reservation());
        }

        [HttpPost]
        public ActionResult Delete(int reservationId)
        {
            ReservationClient client = new ReservationClient();
            if (client.Delete(reservationId))
            {
                TempData["message"] = string.Format($"The ReservationID {reservationId} was deleted");
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int reservationId)
        {
            ReservationClient client = new ReservationClient();
            return View(client.Read(reservationId));
        }

        [HttpPost]
        public ActionResult Edit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                ReservationClient client = new ReservationClient();
                if (reservation.ReservationId == 0)
                {
                    client.Create(reservation);
                }
                else
                {
                    if (client.Update(reservation))
                    {
                        TempData["message"] = string.Format($"The ReservationID " +
                            $"{reservation.ReservationId} has been saved");
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(reservation);
            }
        }
    }
}