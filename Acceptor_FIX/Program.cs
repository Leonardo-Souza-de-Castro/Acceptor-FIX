﻿using log4net;
using log4net.Config;
using QuickFix;
using System;


namespace Acceptor_FIX
{
    public class Program
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            SessionSettings settings = new SessionSettings(args[0]);
            IApplication myApp = new MyApp();
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
                myApp,
                storeFactory,
                settings,
                logFactory);

            //Adicionar em args o caminho para os arquivos
            XmlConfigurator.Configure(new System.IO.FileInfo(args[1]));

            acceptor.Start();
            log.Info("Acceptor Iniciado");
            Console.WriteLine("Caso queira encerrar digite Q");
            string leitura = Console.ReadLine();
            if (leitura != null)
            {
                acceptor.Stop();
                log.Info("Acceptor Finalizado");
            }

        }
    }
}
