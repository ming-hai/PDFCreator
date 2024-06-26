using pdfforge.PDFCreator.Conversion.ActionsInterface;
using pdfforge.PDFCreator.Conversion.Jobs.Jobs;
using pdfforge.PDFCreator.Conversion.Settings;
using pdfforge.PDFCreator.Core.JobInfoQueue;
using pdfforge.PDFCreator.Core.Services.Translation;
using pdfforge.PDFCreator.Core.SettingsManagementInterface;
using pdfforge.PDFCreator.Utilities;
using SystemInterface.IO;

namespace pdfforge.PDFCreator.Core.ComImplementation
{
    public interface IPrintJobAdapterFactory
    {
        PrintJobAdapter BuildPrintJobAdapter(Job job);
    }

    public class PrintJobAdapterFactory : IPrintJobAdapterFactory
    {
        private readonly IDirectory _directory;
        private readonly IPathUtil _pathUtil;
        private readonly IActionOrderHelper _actionOrderHelper;
        private readonly ErrorCodeInterpreter _errorCodeInterpreter;
        private readonly IJobInfoQueue _jobInfoQueue;
        private readonly ISettingsProvider _settingsProvider;
        private readonly ThreadPool _threadPool;
        private readonly IComWorkflowFactory _workflowFactory;

        public PrintJobAdapterFactory(ISettingsProvider settingsProvider, IComWorkflowFactory workflowFactory, ThreadPool threadPool, IJobInfoQueue jobInfoQueue, ErrorCodeInterpreter errorCodeInterpreter, IDirectory directory, IPathUtil pathUtil, IActionOrderHelper actionOrderHelper)
        {
            _settingsProvider = settingsProvider;
            _workflowFactory = workflowFactory;
            _threadPool = threadPool;
            _jobInfoQueue = jobInfoQueue;
            _errorCodeInterpreter = errorCodeInterpreter;
            _directory = directory;
            _pathUtil = pathUtil;
            _actionOrderHelper = actionOrderHelper;
        }

        public PrintJobAdapter BuildPrintJobAdapter(Job job)
        {
            var printJobAdapter = new PrintJobAdapter(_settingsProvider, _workflowFactory, _threadPool, _jobInfoQueue, _errorCodeInterpreter, _directory, _pathUtil, _actionOrderHelper);

            printJobAdapter.Job = job;
            printJobAdapter.SetProfileByGuid(ProfileGuids.DEFAULT_PROFILE_GUID);

            return printJobAdapter;
        }
    }
}
