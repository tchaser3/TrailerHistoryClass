/* Title:           Trailer History Class
 * Date:            8-29-18
 * Author:          Terry Holmes
 * 
 * Description:     This class is used to access Trailer History */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TrailerHistoryDLL
{
    public class TrailerHistoryClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        TrailerHistoryDataSet aTrailerHistoryDataSet;
        TrailerHistoryDataSetTableAdapters.trailerhistoryTableAdapter aTrailerHistoryTableAdapter;

        InsertTrailerHistoryEntryTableAdapters.QueriesTableAdapter aInsertTrailerHistoryTableAdapter;

        FindTrailerHistoryByTrailerIDDataSet aFindTrailerHistoryByTrailerIDDataSet;
        FindTrailerHistoryByTrailerIDDataSetTableAdapters.FindTrailerHistoryByTrailerIDTableAdapter aFindTrailerHistoryByTrailerIDTableAdapter;

        FindTrailerHistoryByEmployeeIDDataSet aFindTrailerHistoryByEmployeeIDDataSet;
        FindTrailerHistoryByEmployeeIDDataSetTableAdapters.FindTrailerHistoryByEmployeeIDTableAdapter aFindTrailerHistoryByEmployeeIDTableAdapter;

        FindTrailerHistoryByDateRangeDataSet aFindTrailerHistoryByDateRangeDataSet;
        FindTrailerHistoryByDateRangeDataSetTableAdapters.FindTrailerHistoryByDateRangeTableAdapter aFindTrailerHistoryByDateRangeTableAdapter;

        public FindTrailerHistoryByDateRangeDataSet FindTrailerHistoryByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindTrailerHistoryByDateRangeDataSet = new FindTrailerHistoryByDateRangeDataSet();
                aFindTrailerHistoryByDateRangeTableAdapter = new FindTrailerHistoryByDateRangeDataSetTableAdapters.FindTrailerHistoryByDateRangeTableAdapter();
                aFindTrailerHistoryByDateRangeTableAdapter.Fill(aFindTrailerHistoryByDateRangeDataSet.FindTrailerHistoryByDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Find Trailer History By Date Range " + Ex.Message);
            }

            return aFindTrailerHistoryByDateRangeDataSet;
        }
        public FindTrailerHistoryByEmployeeIDDataSet FindTrailerHistoryByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindTrailerHistoryByEmployeeIDDataSet = new FindTrailerHistoryByEmployeeIDDataSet();
                aFindTrailerHistoryByEmployeeIDTableAdapter = new FindTrailerHistoryByEmployeeIDDataSetTableAdapters.FindTrailerHistoryByEmployeeIDTableAdapter();
                aFindTrailerHistoryByEmployeeIDTableAdapter.Fill(aFindTrailerHistoryByEmployeeIDDataSet.FindTrailerHistoryByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Find Trailer History By Employee ID " + Ex.Message);
            }

            return aFindTrailerHistoryByEmployeeIDDataSet;
        }
        public FindTrailerHistoryByTrailerIDDataSet FindTrailerHistoryByTrailerID(int intTrailerID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindTrailerHistoryByTrailerIDDataSet = new FindTrailerHistoryByTrailerIDDataSet();
                aFindTrailerHistoryByTrailerIDTableAdapter = new FindTrailerHistoryByTrailerIDDataSetTableAdapters.FindTrailerHistoryByTrailerIDTableAdapter();
                aFindTrailerHistoryByTrailerIDTableAdapter.Fill(aFindTrailerHistoryByTrailerIDDataSet.FindTrailerHistoryByTrailerID, intTrailerID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Find Trailer History By Trailer ID " + Ex.Message);
            }

            return aFindTrailerHistoryByTrailerIDDataSet;
        }
        public bool InsertTrailerHistory(int intTrailerID, int intEmployeeID, int intWarehouseEmployeeID, string strHistoryNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTrailerHistoryTableAdapter = new InsertTrailerHistoryEntryTableAdapters.QueriesTableAdapter();
                aInsertTrailerHistoryTableAdapter.InsertTrailerHistory(intTrailerID, intEmployeeID, intWarehouseEmployeeID, DateTime.Now, strHistoryNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Insert Trailer History " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TrailerHistoryDataSet GetTrailerHistoryInfo()
        {
            try
            {
                aTrailerHistoryDataSet = new TrailerHistoryDataSet();
                aTrailerHistoryTableAdapter = new TrailerHistoryDataSetTableAdapters.trailerhistoryTableAdapter();
                aTrailerHistoryTableAdapter.Fill(aTrailerHistoryDataSet.trailerhistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Get Trailer History Info " + Ex.Message);
            }

            return aTrailerHistoryDataSet;
        }
        public void UpdateTrailerHistoryDB(TrailerHistoryDataSet aTrailerHistoryDataSet)
        {
            try
            {
                aTrailerHistoryTableAdapter = new TrailerHistoryDataSetTableAdapters.trailerhistoryTableAdapter();
                aTrailerHistoryTableAdapter.Update(aTrailerHistoryDataSet.trailerhistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer History Class // Update Trailer History DB " + Ex.Message);
            }
        }
    }
}
