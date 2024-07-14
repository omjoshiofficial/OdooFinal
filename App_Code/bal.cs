/// <summary>
/// Summary description for Cal
/// </summary>
public class regcus_bal
{
    public int User_id { get; set; }

    public string User_name { get; set; }

    public string User_email { get; set; }

    public string User_password { get; set; }

    public string User_mobile { get; set; }
    public string Name { get; set; }
    public string Dob { get; set; }
    public string College { get; set; }
    public string City { get; set; }
    public string gender { get; set; }
    public string Role { get; set; }

    public string university { get; set; }
    public int temp_uid { get; set; }


}

public class Paper_Entry
{
    public int paperid { get; set; }
    public int User_id { get; set; }

    public string paper_name { get; set; }
    public string college_name { get; set; }
    public string university_name { get; set; }
    public string paper_image { get; set; }
    public string paper_pdf { get; set; }
    public string paper_desc { get; set; }
    public string datetime { get; set; }

    public int college_id { get; set; }

    public int stream_id { get; set; }

    public string sem { get; set; }
    public int university_id { get; set; }

}

public class Material_Entry
{
    public int materialid { get; set; }
    public int User_id { get; set; }

    public string material_name { get; set; }
    public int college_id { get; set; }

    public int stream_id { get; set; }

    public string sem { get; set; }
    public int university_id { get; set; }
    public string material_image { get; set; }
    public string material_pdf { get; set; }
    public string material_desc { get; set; }
    public string datetime { get; set; }
}
public class University_Entry
{
    public int university_id { get; set; }
    public string University_name { get; set; }

}

public class College_Entry
{
    public int college_id { get; set; }
    public int university_id { get; set; }
    public int stream_id { get; set; }
    public string College_name { get; set; }
    public string University_name { get; set; }
    public string stream_name { get; set; }
    public string sem { get; set; }

}
public class Function_RoleRight
{
    public int roleid { get; set; }
    public int userid { get; set; }
    public int fn_roleid { get; set; }
    public string user_role { get; set; }
}
