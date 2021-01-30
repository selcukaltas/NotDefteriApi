using Microsoft.AspNet.Identity;
using NotDefteriApi.Dtos;
using NotDefteriApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotDefteriApi.Controllers
{
    [Authorize]
    public class NotlarController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public List<Not> Listele()
        {
            var userId = User.Identity.GetUserId();
            return db.Notlar.Where(x => x.ApplicationUserId == userId).ToList();
        }
        [HttpPost]
        public IHttpActionResult Ekle(NotEkleDto notEkleDto)
        {
            if (ModelState.IsValid)
            {
                Not not = new Not()
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    Baslik = notEkleDto.Baslik,
                    Icerik = notEkleDto.Icerik,
                    NotZamani = DateTime.Now,
                };
                db.Notlar.Add(not);
                db.SaveChanges();
                return Ok(not);
            }

            return BadRequest(ModelState);
        }
        [HttpPut]
        public IHttpActionResult NotGuncelle(int id, NotGuncelleDto dto)
        {
            if (id != dto.NotId)
            {
                return BadRequest();
            }

            var borc = db.Notlar.Find(id);

            if (borc == null)
            {
                return NotFound();
            }

            if (borc.ApplicationUserId != User.Identity.GetUserId())
            {
                return Unauthorized();
            }

            borc.Baslik = dto.Baslik;
            borc.Icerik = dto.Icerik;
            db.SaveChanges();

            return Ok(borc);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var silinecekNot = db.Notlar.Find(id);
            if (silinecekNot == null)
            {
                return NotFound();
            }
            db.Notlar.Remove(silinecekNot);
            db.SaveChanges();
            return Ok(silinecekNot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
