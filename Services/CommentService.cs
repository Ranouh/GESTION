using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Comment;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class CommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
        {
            var comments = await _context.Comments
                .Include(c => c.NoteSections)
                .ToListAsync();

            return comments.Select(comment => comment.ToCommentDto());
        }

        public async Task<CommentDto?> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments
                .Include(c => c.NoteSections)
                .FirstOrDefaultAsync(c => c.IdComment == id);

            return comment?.ToCommentDto();
        }

        public async Task<CommentDto> CreateCommentAsync(CreateCommentRequestDto dto)
        {
            var comment = dto.ToCommentFromCreateDto();
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.ToCommentDto();
        }

        public async Task<CommentDto?> UpdateCommentAsync(int id, UpdateCommentRequestDto dto)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.IdComment == id);
            if (comment == null)
            {
                return null;
            }

            comment.CommentText = dto.CommentText;

            await _context.SaveChangesAsync();
            return comment.ToCommentDto();
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.IdComment == id);
            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}