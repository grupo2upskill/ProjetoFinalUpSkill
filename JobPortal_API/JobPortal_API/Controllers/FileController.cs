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
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FileController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<FileCVDTO>> GetFoto()
        {
            return await _context.FileCV.ProjectTo<FileCVDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID do candidato
        [HttpGet("{id}")]
        public async Task<ActionResult<FileCVDTO>> GetFileCv(int idCandidato)
        {
            if ( _context.FileCV == null)
            {
                return NotFound();
            }
            var fileCv = _context.FileCV.ProjectTo<FileCVDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCandidatoFile == idCandidato);
            if (fileCv == null)
            {
                return NotFound();
            }

            return await fileCv;
        }

       
        //Criar candidato
        [HttpPost]
        public async Task<ActionResult> PostFileCV(FileCVDTO fileCVDTO)
        {
            var fileCV = _mapper.Map<Foto>(fileCVDTO);
            _context.Add(fileCV);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //editar candidato
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutFoto(FileCVDTO fileCVDTO, int id)
        {
            var fileCV = await _context.FileCV.FirstOrDefaultAsync(c => c.IdCandidatoFile == id);
            if (fileCV == null)
            {
                return NotFound();
            }
            fileCV = _mapper.Map(fileCVDTO, fileCV);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFileCV(int id)
        {
            var fileCV = await _context.FileCV.FirstOrDefaultAsync(c => c.IdCandidatoFile == id);
            if (fileCV == null)
            {
                return NotFound();
            }
            _context.FileCV.Remove(fileCV);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
