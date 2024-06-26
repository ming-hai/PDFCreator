using pdfforge.DataStorage.Storage;
using pdfforge.DataStorage;
using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System;

// ! This file is generated automatically.
// ! Do not edit it outside the sections for custom code.
// ! These changes will be deleted during the next generation run

namespace pdfforge.PDFCreator.Conversion.Settings
{
	public partial class Parameters : INotifyPropertyChanged {
		#pragma warning disable 67
		public event PropertyChangedEventHandler PropertyChanged;
		#pragma warning restore 67
		
		
		/// <summary>
		/// OriginalFilePath from command line parameter
		/// </summary>
		public string OriginalFilePath { get; set; } = "";
		
		/// <summary>
		/// Outputfile path from command line parameter
		/// </summary>
		public string Outputfile { get; set; } = "";
		
		/// <summary>
		/// Profile from command line parameter
		/// </summary>
		public string Profile { get; set; } = "";
		
		
		public void ReadValues(Data data, string path = "")
		{
			try { OriginalFilePath = Data.UnescapeString(data.GetValue(@"" + path + @"OriginalFilePath")); } catch { OriginalFilePath = "";}
			try { Outputfile = Data.UnescapeString(data.GetValue(@"" + path + @"Outputfile")); } catch { Outputfile = "";}
			try { Profile = Data.UnescapeString(data.GetValue(@"" + path + @"Profile")); } catch { Profile = "";}
		}
		
		public void StoreValues(Data data, string path)
		{
			data.SetValue(@"" + path + @"OriginalFilePath", Data.EscapeString(OriginalFilePath));
			data.SetValue(@"" + path + @"Outputfile", Data.EscapeString(Outputfile));
			data.SetValue(@"" + path + @"Profile", Data.EscapeString(Profile));
		}
		
		public Parameters Copy()
		{
			Parameters copy = new Parameters();
			
			copy.OriginalFilePath = OriginalFilePath;
			copy.Outputfile = Outputfile;
			copy.Profile = Profile;
			return copy;
		}
		
		public void ReplaceWith(Parameters source)
		{
			if(OriginalFilePath != source.OriginalFilePath)
				OriginalFilePath = source.OriginalFilePath;
				
			if(Outputfile != source.Outputfile)
				Outputfile = source.Outputfile;
				
			if(Profile != source.Profile)
				Profile = source.Profile;
				
		}
		
		public override bool Equals(object o)
		{
			if (!(o is Parameters)) return false;
			Parameters v = o as Parameters;
			
			if (!Object.Equals(OriginalFilePath, v.OriginalFilePath)) return false;
			if (!Object.Equals(Outputfile, v.Outputfile)) return false;
			if (!Object.Equals(Profile, v.Profile)) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			// ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
			return base.GetHashCode();
		}
		
	}
}
