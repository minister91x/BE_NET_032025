using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.Enums
{
    public enum AccountManager_Status
    {
        ACCOUNT_NAME_NOT_VALID = -1,
        ACCOUNT_INSERT_SUCCESS = 1,
        ACCOUNT_UPDATE_SUCCESS = 2,
        ACCOUNT_DELETE_SUCCESS = 3,
        ACCOUNT_GET_LIST_SUCCESS = 4,
        ACCOUNT_GET_LIST_FAIL = 5,
        ACCOUNT_GET_LIST_EMPTY = 6,
        ACCOUNT_GET_LIST_ERROR = 7,
        ACCOUNT_GET_LIST_EXCEPTION = 8,
        ACCOUNT_GET_LIST_TIMEOUT = 9,
        ACCOUNT_GET_LIST_NOT_FOUND = 10
    }
}
