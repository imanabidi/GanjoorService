﻿using RMuseum.Models.Ganjoor;
using RMuseum.Models.Ganjoor.ViewModels;
using RMuseum.Models.GanjoorAudio.ViewModels;
using RMuseum.Models.GanjoorIntegration.ViewModels;
using RSecurityBackend.Models.Generic;
using System;
using System.Threading.Tasks;

namespace RMuseum.Services
{
    /// <summary>
    /// Ganjoor Poems Content Privider Service
    /// </summary>
    public interface IGanjoorService
    {
        /// <summary>
        /// Get List of poets
        /// </summary>
        /// <param name="websitePoets"></param>
        /// <param name="includeBio"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoetViewModel[]>> GetPoets(bool websitePoets, bool includeBio = true);

        /// <summary>
        /// get poet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoetCompleteViewModel>> GetPoetById(int id);

        /// <summary>
        /// get poet by url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoetCompleteViewModel>> GetPoetByUrl(string url);

        /// <summary>
        /// get cat by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="poems"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoetCompleteViewModel>> GetCatById(int id, bool poems = true);

        /// <summary>
        /// get cat by url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="poems"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoetCompleteViewModel>> GetCatByUrl(string url, bool poems = true);

        /// <summary>
        /// get page by url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="catPoems"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPageCompleteViewModel>> GetPageByUrl(string url, bool catPoems = true);

        /// <summary>
        /// get page url by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RServiceResult<string>> GetPageUrlById(int id);

        /// <summary>
        /// Get Poem By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catInfo"></param>
        /// <param name="catPoems"></param>
        /// <param name="rhymes"></param>
        /// <param name="recitations"></param>
        /// <param name="images"></param>
        /// <param name="songs"></param>
        /// <param name="comments"></param>
        /// <param name="verseDetails"></param>
        /// <param name="navigation"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoemCompleteViewModel>> GetPoemById(int id, bool catInfo = true, bool catPoems = false, bool rhymes = true, bool recitations = true, bool images = true, bool songs = true, bool comments = true, bool verseDetails = true, bool navigation = true);

        /// <summary>
        /// Get Poem By Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="catInfo"></param>
        /// <param name="catPoems"></param>
        /// <param name="rhymes"></param>
        /// <param name="recitations"></param>
        /// <param name="images"></param>
        /// <param name="songs"></param>
        /// <param name="comments"></param>
        /// <param name="verseDetails"></param>
        /// <param name="navigation"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoemCompleteViewModel>> GetPoemByUrl(string url, bool catInfo = true, bool catPoems = false, bool rhymes = true, bool recitations = true, bool images = true, bool songs = true, bool comments = true, bool verseDetails = true, bool navigation = true);

        /// <summary>
        /// get poem recitations (PlainText/HtmlText are intentionally empty)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RServiceResult<PublicRecitationViewModel[]>> GetPoemRecitations(int id);

        /// <summary>
        /// get poem images by id (some fields are intentionally field with blank or null),
        /// EntityImageId : the most important data field, image url is https://ganjgah.ir/api/images/thumb/{EntityImageId}.jpg or https://ganjgah.ir/api/images/norm/{EntityImageId}.jpg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemRelatedImage[]>> GetPoemImages(int id);

        /// <summary>
        /// get poem related songs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="approved"></param>
        /// <param name="trackType"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemMusicTrackViewModel[]>> GetPoemSongs(int id, bool approved, PoemMusicTrackType trackType = PoemMusicTrackType.All);

        /// <summary>
        /// next unreviewed track
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="suggestedById"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemMusicTrackViewModel>> GetNextUnreviewedSong(int skip, Guid suggestedById);

        /// <summary>
        /// suggest song
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="song"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemMusicTrackViewModel>> SuggestSong(Guid userId, PoemMusicTrackViewModel song);

        /// <summary>
        /// get unreviewed count
        /// </summary>
        /// <param name="suggestedById"></param>
        /// <returns></returns>
        Task<RServiceResult<int>> GetUnreviewedSongsCount(Guid suggestedById);

        /// <summary>
        /// review song
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemMusicTrackViewModel>> ReviewSong(PoemMusicTrackViewModel song);

        /// <summary>
        /// direct insert song
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task<RServiceResult<PoemMusicTrackViewModel>> DirectInsertSong(PoemMusicTrackViewModel song);

        /// <summary>
        /// new comment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ip"></param>
        /// <param name="poemId"></param>
        /// <param name="content"></param>
        /// <param name="inReplyTo"></param>
        /// <returns></returns>
        Task<RServiceResult<GanjoorCommentSummaryViewModel>> NewComment(Guid userId, string ip, int poemId, string content, int? inReplyTo);

        /// <summary>
        /// update user's own comment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <param name="htmlComment"></param>
        /// <returns></returns>
        Task<RServiceResult<bool>> EditMyComment(Guid userId, int commentId, string htmlComment);

        /// <summary>
        /// delete user own comment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Task<RServiceResult<bool>> DeleteMyComment(Guid userId, int commentId);

        /// <summary>
        /// get recent comments
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        Task<RServiceResult<(PaginationMetadata PagingMeta, GanjoorCommentFullViewModel[] Items)>> GetRecentComments(PagingParameterModel paging);

        /// <summary>
        /// report a comment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="report"></param>
        /// <returns>id of report record</returns>
        Task<RServiceResult<int>> ReportComment(Guid userId, GanjoorPostReportCommentViewModel report);

        /// <summary>
        /// Get list of reported comments
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        Task<RServiceResult<(PaginationMetadata PagingMeta, GanjoorCommentAbuseReportViewModel[] Items)>> GetReportedComments(PagingParameterModel paging);

        /// <summary>
        /// get a random poem from hafez
        /// </summary>
        /// <returns></returns>
        Task<RServiceResult<GanjoorPoemCompleteViewModel>> Faal();

        /// <summary>
        /// imports unimported poem data from a locally accessible ganjoor SqlLite database
        /// </summary>
        /// <returns></returns>
        Task<RServiceResult<bool>> ImportLocalSQLiteDb();

        /// <summary>
        /// import GanjoorPage entity data from MySql
        /// </summary>
        /// <returns></returns>
        RServiceResult<bool> ImportFromMySql();

        /// <summary>
        /// Get Verses By query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="poetId"></param>
        /// <param name="pagingParameterModel"></param>
        /// <returns></returns>
        Task<RServiceResult<(PaginationMetadata PagingMeta, GanjoorSearchVerseViewModel[] items)>> GetVersesByQuery(string query, int poetId,
            PagingParameterModel pagingParameterModel);
    }
}
