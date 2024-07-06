using System;

public class Record{

    public string FirstUserName { get; set;}
    public string SecondUserName { get; set;}

    public int ScoreFirst { get; set; }
    public int ScoreSecond { get; set; }

    public override string ToString()
    {
        return $"{FirstUserName},{SecondUserName},{ScoreFirst},{ScoreSecond}";
    }

    public static Record FromString(string recordString)
    {
        var parts = recordString.Split(',');
        if (parts.Length == 4)
        {
            string firstUsername = parts[0];
            string secondUsername = parts[1];
            int firstUserScore = int.Parse(parts[2]);
            int secondUserScore = int.Parse(parts[3]);
            return new Record(firstUsername, secondUsername, firstUserScore, secondUserScore);
        }
        throw new FormatException("Invalid format of record");
    }

    public Record( string firstusername, string secondusername, int scorefirst, int scoresecond){
        FirstUserName = firstusername;
        SecondUserName = secondusername;
        ScoreFirst = scorefirst;
        ScoreSecond = scoresecond;
    }
}   