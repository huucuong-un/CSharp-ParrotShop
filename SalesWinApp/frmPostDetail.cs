﻿using BusinessObject.Models;
using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmPostDetail : Form
    {

        IPostRepository postRepository = new PostRepository();
        public bool InsertOrUpdate { get; set; }

        public int PostId { get; set; }
        public frmPostDetail()
        {
            InitializeComponent();
        }

        private void frmPostDetail_Load(object sender, EventArgs e)
        {

            if (!InsertOrUpdate)
            {


                var post = postRepository.GetOneById(PostId);
                txtContent.Text = post.PostContent;
                txtPostId.Text = post.PostId.ToString();
                txtTitle.Text = post.PostTitle;



            }
            else
            {



            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int contentLength = txtContent.Text.Length;
            if (contentLength > 600 || contentLength < 1)
            {
                MessageBox.Show("Content must between 1 - 600 words");
                return;
            }

            PostDTO post = new PostDTO()
            {

                PostContent = txtContent.Text,
                PostTitle = txtTitle.Text,

            };

            if (InsertOrUpdate == true)
            {

                postRepository.Add(post);
            }
            else
            {
                post.PostId = PostId;
                postRepository.Updated(post);
            }
            this.Hide();
            this.DialogResult = DialogResult.OK;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
