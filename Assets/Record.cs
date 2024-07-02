public class Record{

    public string FirstUserName { get; set;}
    public string SecondUserName { get; set;}

    public int ScoreFirst { get; set; }
    public int ScoreSecond { get; set; }

    public Record( string firstusername, string secondusername, int scorefirst, int scoresecond){
        FirstUserName = firstusername;
        SecondUserName = secondusername;
        ScoreFirst = scorefirst;
        ScoreSecond = scoresecond;
    }
}   