public class GetScoreMessage : SocketMessage
{

    public GetScoreMessage(string playerId) : base(playerId)
    {
        messageType = MessageType.GET_SCORE;
    }
}