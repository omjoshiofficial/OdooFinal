using System;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for dal
/// </summary>
public class connection
{
    public SqlConnection cn;
    public SqlCommand cmd;
    public SqlDataAdapter da;
    public DataSet ds;

    public void mycon()
    {
        cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ExamHelper.mdf;Integrated Security=True");
        cn.Open();
    }

}

public class dal : connection
{
    public DataSet User_master_roleRight()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster", cn);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();
            return ds;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    //public DataSet Role_Right(Paper_Entry bal)
    //{
    //    mycon();

    //    try
    //    {
    //        cmd = new SqlCommand("select * from RoleRight where userid=@userid",cn);
    //        cmd.Parameters.AddWithValue("@userid", bal.User_id);

    //        da = new SqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);

    //        cn.Close();
    //        return ds;
    //    }
    //    catch (Exception)
    //    {
    //        cn.Close();
    //        throw;
    //    }
    //}

    public DataSet Role_right_Master(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select distinct * from UserMaster u inner join RoleRight r on r.user_role=u.Role where u.userid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.User_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Role_right_page_according(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster u inner join RoleRight r on r.user_role=u.Role inner join Function_Role f on f.fn_roleid=r.fn_roleid where u.userid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.User_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Role_name_drop()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from RoleMaster", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Search_Clientside(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select p.paper_name,p.paperid,p.paper_image,p.paper_pdf , p.sem , p.paper_desc , u.University_name , c.College_name , s.stream_name from StreamMaster s inner join CollegeMaster c on s.college_id=c.college_id inner join UniversityMaster u on u.university_id=c.university_id inner join PaperMaster p on p.college_id=c.college_id where u.university_id like @uname and c.college_id like @cname and s.stream_id like @sname and p.sem like @sem ", cn);
            cmd.Parameters.AddWithValue("@uname", clg.university_id);
            cmd.Parameters.AddWithValue("@cname", clg.college_id);
            cmd.Parameters.AddWithValue("@sname", clg.stream_id);
            cmd.Parameters.AddWithValue("@sem", clg.sem);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataSet Search_Clientside_material(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select p.material_name,p.materialid,p.material_image,p.material_pdf , p.sem , p.material_desc , u.University_name , c.College_name , s.stream_name from StreamMaster s inner join CollegeMaster c on s.college_id=c.college_id inner join UniversityMaster u on u.university_id=c.university_id inner join MaterialMaster p on p.college_id=c.college_id where u.university_id like @uname and c.college_id like @cname and s.stream_id like @sname and p.sem like @sem ", cn);
            cmd.Parameters.AddWithValue("@uname", clg.university_id);
            cmd.Parameters.AddWithValue("@cname", clg.college_id);
            cmd.Parameters.AddWithValue("@sname", clg.stream_id);
            cmd.Parameters.AddWithValue("@sem", clg.sem);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public DataSet Dashboard_count()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select distinct(select COUNT(userid) from UserMaster) as Users,(select COUNT(paperid) from PaperMaster)as Paper,(select COUNT(materialid) from MaterialMaster) as material", cn);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataSet User_cookie(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster where userid=@userid", cn);
            cmd.Parameters.AddWithValue("@userid",bal.User_id);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet User_check(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster where User_email=@email", cn);
            cmd.Parameters.AddWithValue("@email", bal.User_email);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet temp_user_fatch(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from Temp_UserRole t  inner join UserMaster u on u.userid=t.userid where Temp_uid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.User_id);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet temp_user_id_fatch()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from Temp_UserRole t inner join UserMaster u on u.userid=t.userid", cn);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            return ds;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public int insert_temp_user(regcus_bal bal)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from Temp_UserRole where User_email=@cmail", cn);
            cmd.Parameters.AddWithValue("@cmail", bal.User_email);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 2;
            }
            else
            {
                cmd = new SqlCommand("insert into Temp_UserRole values (@uid,@mail,@role,@date)", cn);
                cmd.Parameters.AddWithValue("@uid", bal.User_id);
                cmd.Parameters.AddWithValue("@mail", bal.User_email);
                //cmd.Parameters.AddWithValue("@college", bal.College);
                //cmd.Parameters.AddWithValue("@university", bal.university);
                cmd.Parameters.AddWithValue("@role", bal.Role);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

                cmd.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int delete_tempUser_role(regcus_bal bal)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from Temp_UserRole where Temp_uid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.temp_uid);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet show_temp_userlist()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select t.*,c.College_name,um.University_name from Temp_UserRole t inner join UserMaster u on u.User_email=t.User_email inner join CollegeMaster c on c.college_id=u.college_id inner join UniversityMaster um on um.university_id=c.university_id", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int regcus_insert(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster where User_email=@cmail", cn);
            cmd.Parameters.AddWithValue("@cmail", bal.User_email);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                cmd = new SqlCommand("insert into UserMaster values (@name,@cmail,@cpass,@date,@mobile,@gender,@dob,@college,@address,@cname,@role)", cn);
                cmd.Parameters.AddWithValue("@name", bal.Name);
                cmd.Parameters.AddWithValue("@cmail", bal.User_email);
                cmd.Parameters.AddWithValue("@cpass", bal.User_password);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@mobile", bal.User_mobile);

                cmd.Parameters.AddWithValue("@gender", bal.gender);
                cmd.Parameters.AddWithValue("@dob", bal.Dob);
                cmd.Parameters.AddWithValue("@college", bal.College);
                cmd.Parameters.AddWithValue("@address", bal.City);
                cmd.Parameters.AddWithValue("@cname", bal.User_name);
                cmd.Parameters.AddWithValue("@role", "Student");

                cmd.ExecuteNonQuery();
                cn.Close();

                return 2;
            }

        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }

    }

    public DataSet login(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster where User_email=@mail and User_password=@pass", cn);
            cmd.Parameters.AddWithValue("@mail", bal.User_email);
            cmd.Parameters.AddWithValue("@pass", bal.User_password);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }

        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int forgot(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UserMaster where User_email=@mail", cn);
            cmd.Parameters.AddWithValue("@mail", bal.User_email);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int updated_cus(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("update UserMaster set User_password=@password where User_email=@mail", cn);

            cmd.Parameters.AddWithValue("@password", bal.User_password);
            cmd.Parameters.AddWithValue("@mail", bal.User_email);

            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;


        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }

    }

    public DataSet User_list()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select u.*,c.College_name,um.University_name from UserMaster u inner join CollegeMaster c on u.college_id=c.college_id inner join UniversityMaster um on um.university_id=c.university_id", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int paper_insert(Paper_Entry paper_Entry)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("insert into PaperMaster values (@userid,@paper_name,@college_name,@university_name,@stream_id,@sem,@pimg,@ppdf,@desc,@datetime)", cn);
            cmd.Parameters.AddWithValue("@userid", paper_Entry.User_id);
            cmd.Parameters.AddWithValue("@paper_name", paper_Entry.paper_name);
            cmd.Parameters.AddWithValue("@college_name", paper_Entry.college_id);
            cmd.Parameters.AddWithValue("@university_name", paper_Entry.university_id);
            cmd.Parameters.AddWithValue("@stream_id", paper_Entry.stream_id);
            cmd.Parameters.AddWithValue("@sem", paper_Entry.sem);
            cmd.Parameters.AddWithValue("@pimg", paper_Entry.paper_image);
            cmd.Parameters.AddWithValue("@ppdf", paper_Entry.paper_pdf);
            cmd.Parameters.AddWithValue("@desc", paper_Entry.paper_desc);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());

            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int paper_update(Paper_Entry paper_Entry)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update PaperMaster set paper_name=@name,college_id=@cname,university_id=@uname,stream_id=@sname,@sem=sem,paper_image=@paperimage,paper_pdf=@paperpdf,paper_desc=@paperdesc where paperid=@id", cn);
            cmd.Parameters.AddWithValue("@name", paper_Entry.paper_name);
            cmd.Parameters.AddWithValue("@cname", paper_Entry.college_id);
            cmd.Parameters.AddWithValue("@uname", paper_Entry.university_id);
            cmd.Parameters.AddWithValue("@sname", paper_Entry.stream_id);
            cmd.Parameters.AddWithValue("@sem", paper_Entry.sem);
            cmd.Parameters.AddWithValue("@paperimage", paper_Entry.paper_image);
            cmd.Parameters.AddWithValue("@paperpdf", paper_Entry.paper_pdf);
            cmd.Parameters.AddWithValue("@paperdesc", paper_Entry.paper_desc);
            cmd.Parameters.AddWithValue("@id", paper_Entry.paperid);
            cmd.ExecuteNonQuery();

            return 1;


        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }
    public int material_insert(Material_Entry mat)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into MaterialMaster values(@userid,@material_name,@college_name,@university_name,@stream_id,@sem,@mimg,@mpdf,@mdesc,@datetime)", cn);
            cmd.Parameters.AddWithValue("@userid", mat.User_id);
            cmd.Parameters.AddWithValue("@material_name", mat.material_name);
            cmd.Parameters.AddWithValue("@college_name", mat.college_id);
            cmd.Parameters.AddWithValue("@university_name", mat.university_id);
            cmd.Parameters.AddWithValue("@stream_id", mat.stream_id);
            cmd.Parameters.AddWithValue("@sem", mat.sem);
            cmd.Parameters.AddWithValue("@mimg", mat.material_image);
            cmd.Parameters.AddWithValue("@mpdf", mat.material_pdf);
            cmd.Parameters.AddWithValue("@mdesc", mat.material_desc);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Material_list()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select m.*,c.College_name,u.university_name,s.stream_name from MaterialMaster m inner join CollegeMaster c on c.college_id=m.college_id inner join UniversityMaster u on u.university_id=m.university_id inner join StreamMaster s on s.stream_id=m.stream_id", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }
    public DataSet Material_list_role( regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select m.*,c.College_name,u.university_name,s.stream_name from MaterialMaster m inner join CollegeMaster c on c.college_id=m.college_id inner join UniversityMaster u on u.university_id=m.university_id inner join StreamMaster s on s.stream_id=m.stream_id where userid=@uid", cn);
            cmd.Parameters.AddWithValue("@uid", bal.User_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Material_edit(Material_Entry mat)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from MaterialMaster where materialid=@id", cn);
            cmd.Parameters.AddWithValue("@id", mat.materialid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int delete_Subject_Material(Material_Entry mat)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from MaterialMaster where materialid=@id", cn);
            cmd.Parameters.AddWithValue("@id", mat.materialid);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Material_update(Material_Entry mat)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update MaterialMaster set material_name=@name,college_id=@cname,university_id=@uname,stream_id=@sname,@sem=sem,material_image=@materialimage,material_pdf=@materialpdf,material_desc=@material_desc where materialid=@id", cn);
            cmd.Parameters.AddWithValue("@name", mat.material_name);
            cmd.Parameters.AddWithValue("@cname", mat.college_id);
            cmd.Parameters.AddWithValue("@uname", mat.university_id);
            cmd.Parameters.AddWithValue("@sname", mat.stream_id);
            cmd.Parameters.AddWithValue("@sem", mat.sem);
            cmd.Parameters.AddWithValue("@materialimage", mat.material_image);
            cmd.Parameters.AddWithValue("@materialpdf", mat.material_pdf);
            cmd.Parameters.AddWithValue("@material_desc", mat.material_desc);
            cmd.Parameters.AddWithValue("@id", mat.materialid);
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet College_dropdown_fill()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from CollegeMaster", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet college_drop_according_uni(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select distinct College_name,college_id from CollegeMaster where university_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", clg.university_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            return ds;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet College_name()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select distinct c.College_name,c.college_id,u.University_name,u.university_id from CollegeMaster c inner join UniversityMaster u on c.university_id=u.university_id", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Edit_College_name(College_Entry college)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from CollegeMaster where college_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", college.college_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int Update_College_name(College_Entry college)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("update CollegeMaster set College_name=@name,university_id=@uid where college_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", college.college_id);
            cmd.Parameters.AddWithValue("@uid", college.university_id);
            cmd.Parameters.AddWithValue("@name", college.College_name);

            cmd.ExecuteNonQuery();

            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int College_insert(College_Entry college)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from CollegeMaster where College_name=@name", cn);
            cmd.Parameters.AddWithValue("@name", college.College_name);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 2;
            }
            else
            {

                cmd = new SqlCommand("insert into CollegeMaster values (@uid,@Cname)", cn);
                cmd.Parameters.AddWithValue("@uid", college.university_id);
                cmd.Parameters.AddWithValue("@Cname", college.College_name);

                cmd.ExecuteNonQuery();

                cn.Close();
                return 1;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int delete_College(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from CollegeMaster where college_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", clg.college_id);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet University_name()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UniversityMaster", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Edit_University_name(University_Entry un)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from UniversityMaster where university_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", un.university_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int Update_University_name(University_Entry un)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("update UniversityMaster set University_name=@uname where university_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", un.university_id);
            cmd.Parameters.AddWithValue("@uname", un.University_name);
            
            cmd.ExecuteNonQuery();

            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int delete_University(University_Entry university)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from UniversityMaster where university_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", university.university_id);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int University_insert(University_Entry university)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from UniversityMaster where University_name=@name", cn);
            cmd.Parameters.AddWithValue("@name", university.University_name);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                cmd = new SqlCommand("insert into UniversityMaster values (@name)", cn);
                cmd.Parameters.AddWithValue("@name", university.University_name);

                cmd.ExecuteNonQuery();
                cn.Close();

                return 2;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int delete_University_paper(Paper_Entry paper)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from PaperMaster where paperid=@id", cn);
            cmd.Parameters.AddWithValue("@id", paper.paperid);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet stream_dropfill()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from StreamMaster", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet stream_drop_according_uni(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from StreamMaster where college_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", clg.college_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            return ds;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet stream_list()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select u.University_name,c.College_name , s.stream_name,s.stream_id from StreamMaster s inner join CollegeMaster c on c.college_id=s.college_id inner join UniversityMaster u on u.university_id=c.university_id", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet Edit_stream_name(College_Entry college)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select u.university_id, c.college_id , s.stream_name from StreamMaster s inner join CollegeMaster c on c.college_id=s.college_id inner join UniversityMaster u on u.university_id=c.university_id where stream_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", college.stream_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int Update_Stream_name(College_Entry college)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("update StreamMaster set college_id=@cid,stream_name=@name where stream_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", college.stream_id);
            cmd.Parameters.AddWithValue("@cid", college.college_id);
            cmd.Parameters.AddWithValue("@name", college.stream_name);

            cmd.ExecuteNonQuery();

            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int delete_stream(College_Entry clg)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from StreamMaster where stream_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", clg.stream_id);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int stream_insert(College_Entry college)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from StreamMaster where stream_name=@name and college_id=@id", cn);
            cmd.Parameters.AddWithValue("@name", college.stream_name);
            cmd.Parameters.AddWithValue("@id", college.college_id);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 2;
            }
            else
            {
                cmd = new SqlCommand("insert into StreamMaster values (@cid,@sname)", cn);
                cmd.Parameters.AddWithValue("@cid", college.college_id);
                cmd.Parameters.AddWithValue("@sname", college.stream_name);

                cmd.ExecuteNonQuery();

                cn.Close();
                return 1;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet Paper_list(regcus_bal bal)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select p.*,c.College_name,u.university_name,s.stream_name from PaperMaster p inner join CollegeMaster c on c.college_id=p.college_id inner join UniversityMaster u on u.university_id=p.university_id inner join StreamMaster s on s.stream_id=p.stream_id where userid=@uid", cn);
            cmd.Parameters.AddWithValue("@uid", bal.User_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }
    public DataSet Paper_list_Client()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select p.*,c.College_name,u.university_name,s.stream_name from PaperMaster p inner join CollegeMaster c on c.college_id=p.college_id inner join UniversityMaster u on u.university_id=p.university_id inner join StreamMaster s on s.stream_id=p.stream_id", cn);
         
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }
     public DataSet material_list_Client()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select m.*,c.College_name,u.university_name,s.stream_name from MaterialMaster m inner join CollegeMaster c on c.college_id=m.college_id inner join UniversityMaster u on u.university_id=m.university_id inner join StreamMaster s on s.stream_id=m.stream_id", cn);
         
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet University_popup(Paper_Entry paper_Entry)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from PaperMaster where paperid=@id", cn);
            cmd.Parameters.AddWithValue("@id", paper_Entry.paperid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }
    public int insert_addUser(regcus_bal bal)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into UserMaster values (@name,@cmail,@cpass,@date,@mobile,@gender,@dob,@college,@address,@cname,@role)", cn);
            cmd.Parameters.AddWithValue("@name", bal.Name);
            cmd.Parameters.AddWithValue("@cmail", bal.User_email);
            cmd.Parameters.AddWithValue("@cpass", bal.User_password);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@mobile", bal.User_mobile);

            cmd.Parameters.AddWithValue("@gender", bal.gender);
            cmd.Parameters.AddWithValue("@dob", bal.Dob);
            cmd.Parameters.AddWithValue("@college", bal.College);
            cmd.Parameters.AddWithValue("@address", bal.City);
            cmd.Parameters.AddWithValue("@cname", bal.User_name);
            cmd.Parameters.AddWithValue("@role", bal.Role);

            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public int update_addUser(regcus_bal bal)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update UserMaster set name=@name,User_email=@mail,User_password=@pass,datetime=@date,User_mobile=@mobile,gender=@gender,Dob=@dob,college_id=@college,City=@city,User_name=@username,Role=@role where userid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.User_id);
            cmd.Parameters.AddWithValue("@name", bal.Name);
            cmd.Parameters.AddWithValue("@mail", bal.User_email);
            cmd.Parameters.AddWithValue("@pass", bal.User_password);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@mobile", bal.User_mobile);
            cmd.Parameters.AddWithValue("@gender", bal.gender);
            cmd.Parameters.AddWithValue("@dob", bal.Dob);
            cmd.Parameters.AddWithValue("@college", bal.College);
            cmd.Parameters.AddWithValue("@city", bal.City);
            cmd.Parameters.AddWithValue("@username", bal.User_name);
            cmd.Parameters.AddWithValue("@role", bal.Role);

            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public int delete_addUser(regcus_bal bal)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from UserMaster where userid=@id", cn);
            cmd.Parameters.AddWithValue("@id", bal.User_id);
            cmd.ExecuteNonQuery();
            cn.Close();

            return 1;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet function_role()
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from Function_Role", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public DataSet function_role_drop_select(Function_RoleRight fun)
    {
        mycon();

        try
        {
            cmd = new SqlCommand("select * from Function_Role f inner join RoleRight r on r.fn_roleid=f.fn_roleid where r.user_role=@role", cn);
            cmd.Parameters.AddWithValue("@role", fun.user_role);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

    public int insert_RoleRight(Function_RoleRight fn)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into RoleRight values (@fn_roleid,@user_roleid)", cn);
            cmd.Parameters.AddWithValue("@fn_roleid",fn.fn_roleid);
            cmd.Parameters.AddWithValue("@user_roleid", fn.user_role);

            cmd.ExecuteNonQuery();

            cn.Close();
            return 1;
        }
        catch (Exception)
        {
            cn.Close();
            throw;
        }
    }

}