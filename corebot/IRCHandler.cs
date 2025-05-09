using System;
using corebot;
using NetIRC;
using System.Threading;
using System.Threading.Tasks;
using NetIRC.Connection;
using NetIRC.Messages;

public class IRCHandler
{
	public BotConfig _botConfig;
	public UserConfig _userConfig;
	
	public Client _ircClient;
	public User _ircUser;
	public IRCServer _ircServer;

	public TcpClientConnection _ircConnection;

	public IRCHandler(BotConfig botConfig, UserConfig userConfig)
	{
		this._botConfig = botConfig;
		this._userConfig = userConfig;

		this._ircUser = new User(botConfig.loadedConfig.BotNick, botConfig.loadedConfig.Gecos);

		if (botConfig.loadedConfig.ServerList.Count < 1)
			throw new Exception("No servers configured. Check corebot.conf.");

        this._ircServer = new IRCServer(botConfig.loadedConfig.ServerList[0].hostname, botConfig.loadedConfig.ServerList[0].port.GetValueOrDefault(6667), botConfig.loadedConfig.ServerList[0].password);

		this._ircConnection = new TcpClientConnection(this._ircServer.hostname, this._ircServer.port.GetValueOrDefault(6667));

        this._ircClient = new Client(this._ircUser, this._ircConnection);

        this._ircClient.IRCMessageParsed += _ircClient_IRCMessageParsed;
        this._ircClient.CtcpReceived += _ircClient_CtcpReceived;
        this._ircClient.RawDataReceived += _ircClient_RawDataReceived;
        this._ircClient.RegistrationCompleted += _ircClient_RegistrationCompleted;

        this._ircClient.Queries.CollectionChanged += Queries_CollectionChanged;
        this._ircClient.Channels.CollectionChanged += Channels_CollectionChanged;

        this._ircClient.RegisterCustomMessageHandlers(typeof(Program).Assembly);

    }

    public async void Run()
    {
        await this._ircClient.ConnectAsync();
        await Task.Delay(Timeout.Infinite);
    }

    private void Channels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
//        throw new NotImplementedException();
    }

    private void Queries_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
//        throw new NotImplementedException();
    }

    private void _ircClient_RegistrationCompleted(object? sender, EventArgs e)
    {
 //       throw new NotImplementedException();
    }

    private void _ircClient_RawDataReceived(Client client, string rawData)
    {
        Console.WriteLine(rawData);
//        throw new NotImplementedException();
    }

    private void _ircClient_CtcpReceived(Client client, NetIRC.Ctcp.CtcpEventArgs ctcpEventArgs)
    {
        //        throw new NotImplementedException();

//        Console.WriteLine("Received CTCP Message from " + ctcpEventArgs.From + ", command = " + ctcpEventArgs.CtcpCommand + ", sent to: " + ctcpEventArgs.To);        

        if(ctcpEventArgs.CtcpCommand == "VERSION")
        {
            this._ircClient.SendAsync(new CtcpReplyMessage(ctcpEventArgs.From, "VERSION Test Version Reply"));
        }

    }

    private void _ircClient_IRCMessageParsed(Client client, ParsedIRCMessage ircMessage)
    {
//        throw new NotImplementedException();
    }
}
