
[System.Serializable]
public class AWS_Return_SignUp
{
    public string email;
    public string errorMsg;

}


[System.Serializable]
public class AWS_Return_Login
{
    public string errorMsg;
    public AWS_Return_Login_data data;
}


[System.Serializable]
public class AWS_Return_Login_data
{
    public string password;
    public string email;
    public AWS_Return_Login_data_userstat userstat;
}

[System.Serializable]
public class AWS_Return_Login_data_userstat
{
    public int age;
    public string username;

}




[System.Serializable]
public class AWS_SignUp_UserStat
{
    public string username;

    public int age;

}


[System.Serializable]
public class Aws_SignUp
{
    public string email;
    public string password;

    public AWS_SignUp_UserStat userstat;

    public Aws_SignUp(string email, string password,
        string username, int age)
    {
        this.email = email;
        this.password = password;

        this.userstat = new AWS_SignUp_UserStat();

        userstat.username = username;
        userstat.age = age;


    }
}


[System.Serializable]
public class Aws_Login
{
    public string email;
    public string password;
}

[System.Serializable]
public class Aws_SignUp_Confirm
{
    public string email;
    public string code;
 
}
