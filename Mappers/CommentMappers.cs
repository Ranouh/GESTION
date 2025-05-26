using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.Dto.Comment;
using GESTION.Dto.NoteSection;
using GESTION.model;
namespace GESTION.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment){
            if(comment==null){
                throw new ArgumentNullException (nameof(comment), "comment is null");
            }
            return new CommentDto {
                IdComment = comment.IdComment,
                CommentText = comment.CommentText,
                NoteSections = comment.NoteSections?.Select(ns=>ns.ToNoteSectionDto()).ToList()?? new List<NoteSectionDto>()
            };
        }
        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto commentDto){
            if(commentDto == null){
                throw new ArgumentNullException(nameof(commentDto), "commentDto is null");
            }
            return new Comment{
                CommentText = commentDto.CommentText
            };
        }
    };
}