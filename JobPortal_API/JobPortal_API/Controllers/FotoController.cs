using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal_API.Data;
using JobPortal_API.DTOs;
using JobPortal_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_API.Controllers
{
    [ApiController]
    [Route("api/foto")]
    public class FotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FotoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<FotoDTO>> GetFoto()
        {
            return await _context.Foto.ProjectTo<FotoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID do candidato
        [HttpGet("{id}")]
        public async Task<ActionResult<FotoDTO>> GetFoto(int idCandidato)
        {
            if ( _context.Foto == null)
            {
                return NotFound();
            }
            var foto = _context.Foto.ProjectTo<FotoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCandidatoFoto == idCandidato);
            if (foto == null)
            {
                return NotFound();
            }

            return await foto;
        }

        ////busca por nome 
        //[HttpGet("{filter}")]
        //public async Task<IEnumerable<Candidato>> Filter(string nome)
        //{
        //    return await _context.Candidato.Where(m => m.Nome.Contains(nome)).ToListAsync();
           
        //}
        //Criar candidato
        [HttpPost]
        public async Task<ActionResult> PostFoto(FotoDTO fotoDTO)
        {
            var foto = _mapper.Map<Foto>(fotoDTO);
            _context.Add(foto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //editar candidato
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutFoto(FotoDTO fotoDTO, int id)
        {
            var foto = await _context.Foto.FirstOrDefaultAsync(c => c.IdCandidatoFoto == id);
            if (foto == null)
            {
                return NotFound();
            }
            foto = _mapper.Map(fotoDTO, foto);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFoto(int id)
        {
            var foto = await _context.Foto.FirstOrDefaultAsync(c => c.IdCandidatoFoto == id);
            if (foto == null)
            {
                return NotFound();
            }
            _context.Foto.Remove(foto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
