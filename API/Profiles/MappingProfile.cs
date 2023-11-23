using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Gama_Producto, Gama_ProductoDto>().ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Pago, Formas_Pago>().ReverseMap();

            CreateMap<Producto, ProductoNomDescImg>()
                .ForMember(dest => dest.Img, opt => opt.MapFrom(en => en.Gama_Producto.Imagen));
            CreateMap<Cliente, ClienteConRepNameYCiudad>()
                .ForMember(
                    dest => dest.Nombre_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Nombre)
                )
                .ForMember(
                    dest => dest.Ciudad_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Oficina.Ciudad)
                )
                .ReverseMap();
            CreateMap<Cliente, ClienteConRepNameApellidoYCiudad>()
                .ForMember(
                    dest => dest.Nombre_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Nombre)
                )
                .ForMember(
                    dest => dest.Apellido_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Apellido1)
                )
                .ForMember(
                    dest => dest.Ciudad_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Oficina.Ciudad)
                )
                .ReverseMap();
            CreateMap<Cliente, ClienteConRepNomApdOficinaTel>()
                .ForMember(
                    dest => dest.Nombre_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Nombre)
                )
                .ForMember(
                    dest => dest.Apellido_Representante,
                    opt => opt.MapFrom(en => en.Empleado.Apellido1)
                )
                .ForMember(
                    dest => dest.Telefono_Oficina,
                    opt => opt.MapFrom(en => en.Empleado.Oficina.Telefono)
                )
                .ReverseMap();
            CreateMap<Empleado, EmpleadoJefeJefe>()
                .ForMember(dest => dest.Nombre_Jefe, opt => opt.MapFrom(en => en.Jefe.Nombre))
                .ForMember(
                    dest => dest.Nombre_Jefe_del_Jefe,
                    opt => opt.MapFrom(en => en.Jefe.Jefe.Nombre)
                )
                .ForAllMembers(opt => opt.NullSubstitute("No tiene jefe"));
        }
    }
}
