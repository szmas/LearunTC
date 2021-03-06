﻿/* * 创建人：超级管理员
 * 日  期：2020-07-10 17:09
 * 描  述：项目管理
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#ApplicantId').lrDataSourceSelect({ code: 'recruitdata',value: 'f_applicantid',text: 'f_companyname' });
            $('#ProjectType').lrDataItemSelect({ code: 'projecttype' });
            $('#SocialSecurities').lrDataItemSelect({ code: 'SocialSecurities' });
            $('#Rank').lrDataItemSelect({ code: 'rank' });
            $('#Status').lrDataItemSelect({ code: 'projectstatus' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/ProjectManage/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/ProjectManage/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
