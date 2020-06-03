using Application.Interfaces;
using Application.ViewModels;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DNA.UI.Web.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-mamanagement/list-all")]
        public IActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteviewModel = _clienteAppService.GetById(id.Value);
            if (clienteviewModel == null)
            {
                return NotFound();
            }

            return View(clienteviewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("custumermanagemnet/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("custumer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteViewModel);
            }
            _clienteAppService.Register(clienteViewModel);

            if (IsValidOperation())
            {
                ViewBag.Sucesso = "Customer Registered!";
            }

            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-custumer/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-custumer/{Id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                View(clienteViewModel);
            }

            _clienteAppService.Update(clienteViewModel);
            if (IsValidOperation())
            {
                ViewBag.Sucesso = "Customer updated!";
            }
            return View(clienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);

            if (!IsValidOperation()) return View(_clienteAppService.GetById(id));

            ViewBag.Sucesso = "Customer Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("customer-management/customer-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var clienteHistoryData = _clienteAppService.GetAllHistory(id);
            return Json(clienteHistoryData);
        }

    }
}