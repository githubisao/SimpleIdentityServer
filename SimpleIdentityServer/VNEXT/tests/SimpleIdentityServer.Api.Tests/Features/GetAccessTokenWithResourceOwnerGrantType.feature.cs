﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdentityServer.Api.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetAccessTokenWithResourceOwnerGrantTypeFeature : Xunit.IClassFixture<GetAccessTokenWithResourceOwnerGrantTypeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetAccessTokenWithResourceOwnerGrantType.feature"
#line hidden
        
        public GetAccessTokenWithResourceOwnerGrantTypeFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetAccessTokenWithResourceOwnerGrantType", "\tAs a resource owner and user of the client\r\n\tI should be able to retrieve an acc" +
                    "ess token with my credentials", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(GetAccessTokenWithResourceOwnerGrantTypeFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token without defining scopes")]
        public virtual void RetrieveAnAccessTokenWithoutDefiningScopes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token without defining scopes", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password"});
            table1.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "loki"});
#line 10
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table1, "When ");
#line 14
 testRunner.Then("http result is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("access token is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with two scopes")]
        public virtual void RetrieveAnAccessTokenWithTwoScopes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with two scopes", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table2.AddRow(new string[] {
                        "roles",
                        "true"});
            table2.AddRow(new string[] {
                        "openid",
                        "true"});
#line 20
 testRunner.And("the scopes are defined", ((string)(null)), table2, "And ");
#line 25
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table3.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "loki",
                        "roles openid"});
#line 27
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table3, "When ");
#line 31
 testRunner.Then("http result is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.And("access token is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("access token have the correct scopes : roles,roles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with missing username")]
        public virtual void RetrieveAnAccessTokenWithMissingUsername()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with missing username", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table4.AddRow(new string[] {
                        "roles",
                        "true"});
            table4.AddRow(new string[] {
                        "openid",
                        "true"});
#line 39
 testRunner.And("the scopes are defined", ((string)(null)), table4, "And ");
#line 44
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "password",
                        "scope"});
            table5.AddRow(new string[] {
                        "MyHolidays",
                        "loki",
                        "roles openid"});
#line 46
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table5, "When ");
#line 50
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("the error is invalid_request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with missing client id")]
        public virtual void RetrieveAnAccessTokenWithMissingClientId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with missing client id", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table6.AddRow(new string[] {
                        "roles",
                        "true"});
            table6.AddRow(new string[] {
                        "openid",
                        "true"});
#line 56
 testRunner.And("the scopes are defined", ((string)(null)), table6, "And ");
#line 61
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "username",
                        "password",
                        "scope"});
            table7.AddRow(new string[] {
                        "thierry",
                        "loki",
                        "roles openid"});
#line 63
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table7, "When ");
#line 67
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.And("the error is invalid_request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with none existing scope")]
        public virtual void RetrieveAnAccessTokenWithNoneExistingScope()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with none existing scope", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table8.AddRow(new string[] {
                        "roles",
                        "true"});
            table8.AddRow(new string[] {
                        "openid",
                        "true"});
#line 73
 testRunner.And("the scopes are defined", ((string)(null)), table8, "And ");
#line 77
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table9.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "loki",
                        "roles openid profile"});
#line 79
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table9, "When ");
#line 83
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.And("the error is invalid_scope", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with a scope not allowed")]
        public virtual void RetrieveAnAccessTokenWithAScopeNotAllowed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with a scope not allowed", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table10.AddRow(new string[] {
                        "roles",
                        "true"});
            table10.AddRow(new string[] {
                        "openid",
                        "true"});
#line 89
 testRunner.And("the scopes are defined", ((string)(null)), table10, "And ");
#line 94
 testRunner.And("the scopes roles are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table11.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "loki",
                        "roles openid"});
#line 96
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table11, "When ");
#line 100
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("the error is invalid_scope", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with duplicate scopes")]
        public virtual void RetrieveAnAccessTokenWithDuplicateScopes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with duplicate scopes", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 104
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table12.AddRow(new string[] {
                        "roles",
                        "true"});
            table12.AddRow(new string[] {
                        "openid",
                        "true"});
#line 106
 testRunner.And("the scopes are defined", ((string)(null)), table12, "And ");
#line 110
 testRunner.And("the scopes roles are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table13.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "loki",
                        "roles roles"});
#line 112
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table13, "When ");
#line 116
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And("the error is invalid_scope", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token for a none existing client_id")]
        public virtual void RetrieveAnAccessTokenForANoneExistingClient_Id()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token for a none existing client_id", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table14.AddRow(new string[] {
                        "roles",
                        "true"});
            table14.AddRow(new string[] {
                        "openid",
                        "true"});
#line 122
 testRunner.And("the scopes are defined", ((string)(null)), table14, "And ");
#line 126
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table15.AddRow(new string[] {
                        "ClientNotAllowed",
                        "thierry",
                        "loki",
                        "roles openid"});
#line 128
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table15, "When ");
#line 132
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
 testRunner.And("the error is invalid_client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "GetAccessTokenWithResourceOwnerGrantType")]
        [Xunit.TraitAttribute("Description", "Retrieve an access token with not valid credentials")]
        public virtual void RetrieveAnAccessTokenWithNotValidCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an access token with not valid credentials", ((string[])(null)));
#line 135
this.ScenarioSetup(scenarioInfo);
#line 136
 testRunner.Given("a resource owner with username thierry and password loki is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 137
 testRunner.And("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table16.AddRow(new string[] {
                        "roles",
                        "true"});
            table16.AddRow(new string[] {
                        "openid",
                        "true"});
#line 138
 testRunner.And("the scopes are defined", ((string)(null)), table16, "And ");
#line 142
 testRunner.And("the scopes roles,openid are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "client_id",
                        "username",
                        "password",
                        "scope"});
            table17.AddRow(new string[] {
                        "MyHolidays",
                        "thierry",
                        "notvalid",
                        "roles openid"});
#line 144
 testRunner.When("requesting an access token via resource owner grant-type", ((string)(null)), table17, "When ");
#line 148
 testRunner.Then("http result is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
 testRunner.And("the error is invalid_grant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetAccessTokenWithResourceOwnerGrantTypeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetAccessTokenWithResourceOwnerGrantTypeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion