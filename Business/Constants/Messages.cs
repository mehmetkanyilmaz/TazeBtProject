using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //User
        public static string UserNotFound = "Kullanıcı bulunamadı";

        //Article
        public static string ArticleAddError = "Makale eklenemedi";
        public static string ArticleSuccessfulDeleted = "Makale başarıyla silindi";
        public static string ArticleDeleteError = "Makale silinemedi";
        public static string ArticleNotFound = "Makale bulunamadı";
        public static string ArticleGetListError = "Makaleler listelenemedi";
        public static string ArticleGetError = "Makale bulunamadı";
        public static string ArticleUpdateError = "Makale güncellenemedi";
        public static string ArticleTitleNull = "Başlık alanı boş";
        public static string ArticleDateNull = "Tarih alanı boş";
        public static string ArticleContentsNull = "İçerik alanı boş";
        public static string ArticleCuserNull = "Oluşturan kullanıcı alanı boş";
        public static string ArticleCuserGreaterThanZero = "Oluşturan kullanıcı alanı sıfırdan büyük olmalı";

        //Article Category
        public static string ArticleCategoryAddError = "Makaleye kategori eklenemedi";
        public static string ArticleCategorySuccessfulDeleted = "Makaleye ait kategori başarıyla silindi";
        public static string ArticleCategoryDeleteError = "Makaleye ait kategori silinemedi";
        public static string ArticleCategoryArticleIdNull = "Makale id alanı boş";
        public static string ArticleCategoryArticleIdGreaterThanZero = "Makale id alanı sıfırdan büyük olmalı";
        public static string ArticleCategoryNameNull = "Kategori adı boş";

        //Category
        public static string CategoryAddError = "Kategori eklenemedi";
        public static string CategorySuccessfulDeleted = "Kategori başarıyla silindi";
        public static string CategoryDeleteError = "Kategori silinemedi";
        public static string CategoryGetListError = "Kategoriler listelenemedi";
        public static string CategoryUpdateError = "Kategori güncellenemedi";

        //Comment
        public static string CommentAddError = "Yorum eklenemedi";
        public static string CommentArticleIdNull = "Makale id alanı boş";
        public static string CommentCommentsNull = "İçerik alanı boş";
        public static string CommentCuserNull = "Oluşturan kullanıcı alanı boş";
        public static string CommentCuserGreaterThanZero = "Oluşturan kullanıcı alanı sıfırdan büyük olmalı";
        public static string CommentDateNull = "Tarih alanı boş";
    }
}
