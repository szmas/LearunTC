﻿using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-07-10 17:09
    /// 描 述：项目管理
    /// </summary>
    public class ProjectManageService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// </summary>
        /// <param name="pagination">查询参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<tc_ProjectEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.ProjectId,
                t.ApplicantId,
                t.RegisterAddress,
                t.ProjectType,
                t.SocialSecurities,
                t.Major,
                t.Rank,
                t.PublishDate,
                t.ConfigDate,
                t.CompleteDate,
                t.Status,
                t.F_Description
                ");
                strSql.Append("  FROM tc_Project t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["ApplicantId"].IsEmpty())
                {
                    dp.Add("ApplicantId",queryParam["ApplicantId"].ToString(), DbType.String);
                    strSql.Append(" AND t.ApplicantId = @ApplicantId ");
                }
                if (!queryParam["ProjectType"].IsEmpty())
                {
                    dp.Add("ProjectType",queryParam["ProjectType"].ToString(), DbType.String);
                    strSql.Append(" AND t.ProjectType = @ProjectType ");
                }
                if (!queryParam["Status"].IsEmpty())
                {
                    dp.Add("Status",queryParam["Status"].ToString(), DbType.String);
                    strSql.Append(" AND t.Status = @Status ");
                }
                if (!queryParam["ApplicantId"].IsEmpty())
                {
                    dp.Add("ApplicantId",queryParam["ApplicantId"].ToString(), DbType.String);
                    strSql.Append(" AND t.ApplicantId = @ApplicantId ");
                }
                return this.BaseRepository().FindList<tc_ProjectEntity>(strSql.ToString(),dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取tc_Project表实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public tc_ProjectEntity Gettc_ProjectEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<tc_ProjectEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<tc_ProjectEntity>(t=>t.ProjectId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        public void SaveEntity(string keyValue, tc_ProjectEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
