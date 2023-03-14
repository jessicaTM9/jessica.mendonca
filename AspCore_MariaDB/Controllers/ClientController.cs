using AspCore_MariaDB.Data;
using AspCore_MariaDB.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_MariaDB.controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public IActionResult GetAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public IActionResult GetClientById(int id)
    {
        var client = _clientService.GetClientById(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpPost]
    public IActionResult AddClient(Client client)
    {
        _clientService.AddClient(client);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _clientService.UpdateClient(client);
        return Ok();

        var clients = _clientService.GetClientById(id);
    if (client == null)
    {
        return NotFound();
    }

    var clientViewModel = new Client
    {
        Id = client.Id,
        Name = client.Name,
        Birthdate = client.Birthdate,
        CPF = client.CPF,
        RG = client.RG,
        Telephone = client.Telephone,
        Addresses = client.Addresses
            .Select(a => new Addresses
            {
                Id = a.Id,
                Street = a.Street,
                Number = a.Number,
                Complement = a.Complement,
                Neighborhood = a.Neighborhood,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode
            }).ToList()
    };

    return (IActionResult)clientViewModel;

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        _clientService.DeleteClient(id);
        return Ok();
    }

}