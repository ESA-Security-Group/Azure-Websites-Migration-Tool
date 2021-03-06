// Copyright (c) Microsoft Technologies, Inc.  All rights reserved. 
// Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved. 
// Licensed under the Apache License, Version 2.0.  
// See License.txt in the project root for license information.

using System;

namespace CompatCheckAndMigrate.ObjectModel
{
    public interface IWizardStep
    {
        event EventHandler<GoToWizardStepEventArgs> GoTo;

        void SetState(object state, bool isNavigatingBack = false);
    }
}
