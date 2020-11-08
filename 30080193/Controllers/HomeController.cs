﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _30080193.Models;
using _30080193.Utils;
using SendGrid.Helpers.Mail;

namespace _30080193.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    String[] to_email = toEmail.Substring(0, toEmail.Length).Split(';');
                    var attachment = Request.Files["postedFile"];

                    if (attachment.ContentLength > 0)
                    {
                        String filePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/"), attachment.FileName);
                        attachment.SaveAs(filePath);

                        EmailSender es = new EmailSender();
                        foreach (String to in to_email)
                        {
                            es.SendBulkEmail(to, subject, contents, User.Identity.Name, filePath, attachment.FileName);
                        }
                        
                    }
                    else
                    {
                        EmailSender es = new EmailSender();
                        foreach (String to in to_email)
                        {
                            es.Send(to, subject, contents, User.Identity.Name);
                        }
                            
                    }

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        public ActionResult loader()
        {
            return View();
        }
    }
}