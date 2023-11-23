using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController:ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Empleados.GetAllAsync();
            var EmpleadoListDto = _mapper.Map<List<EmpleadoDto>>(registers);
            return EmpleadoListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Add(Empleado);
            await _unitOfWork.SaveAsync();
            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoDto>> Put(
            int id,
            [FromBody] EmpleadoDto EmpleadoDto
        )
        {
            if (EmpleadoDto == null)
            {
                return NotFound(404);
            }
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Update(Empleado);
            await _unitOfWork.SaveAsync();
            return EmpleadoDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            _unitOfWork.Empleados.Remove(Empleado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("EmpleadoJefeConJefe")]
        public async Task<ActionResult<IEnumerable<EmpleadoJefeJefe>>> EmpleadoJefeConJefe()
        {
            var r = await _unitOfWork.Empleados.EmpleadoConJefeConJefe();
            return _mapper.Map<List<EmpleadoJefeJefe>>(r);
        }
    }
}